import { DAO } from "../DAO";
import { Request, Response } from "express";
import { ProductsI } from "../models/products.model";
import {
  checkMandatoryDataProducts,
  checkMandatoryDataSpecs,
  checkMandatoryDataCategory,
} from "../validation/mandatory.data.js";
import { SpecificationsI } from "../models/specifications.model";

export default class ProductsController {
  private dao: DAO;

  constructor(dao: DAO) {
    this.dao = dao;
  }

  async getProducts(req: Request, res: Response) {
    res.type("application/json");
    this.dao.fetchAllProducts().then((products: Array<ProductsI>) => {
      res.status(200);
      res.send(JSON.stringify(products));
    });
  }
  async getProductsById(req: Request, res: Response) {
    res.type("application/json");
    const ProductId = parseInt(req.params["id"], 10);
    this.dao.getProductsById(ProductId).then((product: Array<ProductsI>) => {
      res.send(JSON.stringify(product));
    });
  }
  async postProducts(req: Request, res: Response) {
    res.type("application/json");
    let data = req.body;
    const { pc, specifications, category } = data;
    let newProduct = {
      productName: pc.ProductName,
      price: pc.Price,
      premiumOffer: pc.PremiumOffer,
      stock: pc.Stock,
    };
    let newConfiguration: SpecificationsI = {
      productId: specifications.ProductID,
      cpu: specifications.CPU,
      cpuGhz: specifications.CPU_GHz,
      cpuCores: specifications.CPU_Cores,
      gpu: specifications.GPU,
      gpuVram: specifications.GPU_VRAM,
      ram: specifications.RAM,
      ramSize: specifications.RAM_size,
      storageHdd: specifications.Storage_HDD,
      storageSsd: specifications.Storage_SSD,
    };
    let newCategory = {
      productId: category.ProductID,
      categoryId: category.CategoryID,
    };

    if (
      !checkMandatoryDataProducts(
        newProduct.productName,
        newProduct.price,
        newProduct.premiumOffer,
        newProduct.stock
      )
    ) {
      res
        .status(400)
        .send(JSON.stringify({ message: "All fields are mandatory" }));
      return;
    }
    if (
      !checkMandatoryDataSpecs(
        newConfiguration.cpu,
        newConfiguration.cpuGhz,
        newConfiguration.cpuCores,
        newConfiguration.gpu,
        newConfiguration.gpuVram,
        newConfiguration.ram,
        newConfiguration.ramSize,
        newConfiguration.storageHdd,
        newConfiguration.storageSsd
      )
    ) {
      res
        .status(400)
        .send(JSON.stringify({ message: "All fields are mandatory" }));
      return;
    }
    if (!checkMandatoryDataCategory(newCategory.categoryId)) {
      res
        .status(400)
        .send(JSON.stringify({ message: "Please insert category" }));
      return;
    }
    if (Array.isArray(newCategory.categoryId)) {
      for (let i = 0; i < newCategory.categoryId.length; i++) {
        if (![1, 2, 3, 4].includes(newCategory.categoryId[i])) {
          res
            .status(400)
            .send(JSON.stringify({ message: "Please enter valid category" }));
          return;
        }
      }
    }
    if (
      newCategory.categoryId !== 1 &&
      newCategory.categoryId !== 2 &&
      newCategory.categoryId !== 3 &&
      newCategory.categoryId !== 4
    ) {
      res
        .status(400)
        .send(JSON.stringify({ message: "Please enter valid category" }));
      return;
    }

    let stockProducts = await this.dao.fetchAllProducts();
    let existingProduct = stockProducts.find(
      (product) => product.productName == newProduct.productName
    );
    if (existingProduct) {
      res.status(400).json({ message: "Article already exist" });
      return;
    }
    try {
      const newProductId = await this.dao.insertNewProduct(newProduct);
      newConfiguration.productId = newProductId;

      await Promise.all([
        this.dao.insertSpecifications(newConfiguration),
        ...(Array.isArray(newCategory.categoryId)
          ? newCategory.categoryId.map((categoryId) =>
              this.dao.insertCategory(newProductId, categoryId)
            )
          : [this.dao.insertCategory(newProductId, newCategory.categoryId)]), // Ako je single ID, poziva se direktno
      ]);

      res.status(201).send(JSON.stringify({ message: "Article added" }));
    } catch (error) {
      console.error(error);
      res
        .status(500)
        .send(JSON.stringify({ message: "Error while adding an article" }));
    }
  }

  async deleteProduct(req: Request, res: Response) {
    res.type("application/json");
    let data = req.body;
    const {ProductID} = data;

  
    if (isNaN(ProductID)) {
      res.status(400).send(JSON.stringify({ message: "Invalid product ID" }));
      return;
    }
  
    try {
      const product = await this.dao.getProductsById(ProductID);
      
      if (!product || product.length === 0) {
        res.status(404).send(JSON.stringify({ message: "Product not found" }));
        return;
      }
  
      await Promise.all([
        this.dao.deleteProduct(ProductID),
        this.dao.deleteSpecifications(ProductID),
        this.dao.deleteCategories(ProductID),
      ]);
  
      res.status(200).send(JSON.stringify({ message: "Product deleted successfully" }));
      return;
    } catch (error) {
      console.error(error);
      res.status(500).send(JSON.stringify({ message: "Error deleting product" }));
      return;
    }
  }  

}
