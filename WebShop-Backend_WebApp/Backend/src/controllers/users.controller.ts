import { DAO } from "../DAO";
import {Request, Response} from "express";
import jwt from 'jsonwebtoken';
import dotenv from "dotenv";
import { checkMandatoryData } from "../validation/mandatory.data.js";
import { createSHA256 } from "../crypto/password.hash.js";
import { NextFunction } from "express-serve-static-core";
import { CartI } from "../models/cart.model";

export default class UsersController {
  private dao: DAO;
  private accessToken: string;

  constructor(dao: DAO) {
    this.dao = dao;
    this.accessToken = process.env.ACCESS_TOKEN || "defaultSecret";
  }

  async insertUser(req: Request, res: Response, next: NextFunction): Promise<void> {
    res.type("application/json");
    let userData = req.body;
    const {
      FirstName,
      LastName,
      HouseNumber,
      Street,
      StateID,
      Town,
      Email,
      Username,
      Pass,
    } = userData;
    
    const user = {
      firstName: FirstName,
      lastName: LastName,
      houseNumber: HouseNumber,
      street: Street,
      stateId: StateID,
      town: Town,
      email: Email,
      userName: Username,
      password: Pass,
      roleId: 4,
    };

    if (!checkMandatoryData(
        user.firstName,
        user.lastName,
        user.houseNumber,
        user.street,
        user.stateId,
        user.town,
        user.email,
        user.userName,
        user.password
    )) {
        res.status(400).json({ error: "All fields are mandatory" });
        return;
    }

    let alreadyRegisteredUserByEmail = await this.dao.fetchUserbyEmail(user.email);
    let alreadyRegisteredUserByUsername = await this.dao.fetchUserbyUsername(user.userName);

    if (alreadyRegisteredUserByEmail?.email === user.email) {
      res.status(400).json({ message: "Email already in use" });
      return;
    }
    if (alreadyRegisteredUserByUsername?.userName === user.userName) {
      res.status(400).json({ message: "Username already in use" });
      return;
    }

    try {
      const hashedPassword = createSHA256(user.password, "my salt");
      user.password = hashedPassword;
      const newUserId = await this.dao.insertUser(user);
      const createdAt = new Date();
      const newUserCart:CartI = {
        userId: newUserId,
        createdDate: createdAt,
        updatedDate: createdAt,
        cartStatusId: 1
      }
      await this.dao.insertNewCart(newUserCart);
      res.status(201).json({ message: "User added" });
      return;
    } catch (error) {
      console.log(error);
      res.status(500).json({ error: "Error while inserting a user" });
      return;
    }
}


  async loginUser(req: Request, res: Response, next: NextFunction) {
    res.type("application/json");
    let loginData = req.body;
    const { Username, Pass } = loginData;
    const loggedUser = {
      username: Username,
      password: Pass,
    };
    let registeredUser = await this.dao.fetchUserbyUsername(
      loggedUser.username
    );
    if (loggedUser.username === "" || loggedUser.username == null) {
      return res
        .status(400)
        .send(JSON.stringify({ message: "Please insert username" }));
    }
    if (loggedUser.password === "" || loggedUser.password == null) {
      return res
        .status(400)
        .send(JSON.stringify({ message: "Please insert password" }));
    }

    if (registeredUser != null) {
      const hashedPassword = createSHA256(loggedUser.password, "my salt");
      if (registeredUser.password === hashedPassword) {
        const response = {
          userId: registeredUser.userId,
          email: registeredUser.email,
          username: registeredUser.userName,
          roleId: registeredUser.roleId,
        };
        const accessToken = jwt.sign(response, this.accessToken, {
          expiresIn: "1h",
        });
        return res.status(201).send(JSON.stringify({ accessToken }));
      } else {
        return res.status(404).send(JSON.stringify({ error: "Wrong data" }));
      }
    } else {
      return res
        .status(404)
        .send(JSON.stringify({ error: "User do not exist" }));
    }
  }
}