import crypto from "crypto";


export function createSHA256(tekst:string, sol?:string){
	if(sol)
	  return createSHA256withSalt(tekst, sol);
  
	return createSHA256withoutSalt(tekst)
  }

 export  function createSHA256withoutSalt (tekst:string){
	const hash = crypto.createHash('sha256');
	hash.write(tekst);
	var exit = hash.digest('hex');
	hash.end();
	return exit;
}

export function createSHA256withSalt(tekst:string, sol:string){
	const hash = crypto.createHash('sha256');
	hash.write(tekst+sol);
	var exit = hash.digest('hex');
	hash.end();
	return exit;
}