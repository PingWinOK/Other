-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`cash_transactions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`cash_transactions` (
  `idCash_transactions` INT NOT NULL AUTO_INCREMENT,
  `Appointment` SET('invest', 'purchase', 'sale') NULL DEFAULT NULL,
  `Sum` DECIMAL(10,2) UNSIGNED NULL DEFAULT NULL,
  `Date_Time` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`idCash_transactions`))
ENGINE = InnoDB
AUTO_INCREMENT = 10
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `mydb`.`post`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`post` (
  `idPost` INT NOT NULL AUTO_INCREMENT,
  `Name_post` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idPost`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `mydb`.`employee`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`employee` (
  `idEmployees` INT NOT NULL AUTO_INCREMENT,
  `Passport_number` VARCHAR(30) NULL DEFAULT NULL,
  `Phone_number` VARCHAR(30) NULL DEFAULT NULL,
  `Address` VARCHAR(45) NULL DEFAULT NULL,
  `Full_Name` VARCHAR(30) NULL DEFAULT NULL,
  `Post_idPost` INT NOT NULL,
  `SNILS` VARCHAR(30) NULL DEFAULT NULL,
  PRIMARY KEY (`idEmployees`, `Post_idPost`),
  INDEX `fk_Employees_Post1_idx` (`Post_idPost` ASC) VISIBLE,
  CONSTRAINT `fk_Employees_Post1`
    FOREIGN KEY (`Post_idPost`)
    REFERENCES `mydb`.`post` (`idPost`))
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `mydb`.`provider`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`provider` (
  `idProvider` INT NOT NULL AUTO_INCREMENT,
  `Provider_Name` VARCHAR(45) NULL DEFAULT NULL,
  `Address` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idProvider`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `mydb`.`goods`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`goods` (
  `idGoods` INT NOT NULL AUTO_INCREMENT,
  `Quantity` INT NULL DEFAULT NULL,
  `Product_Name` VARCHAR(45) NULL DEFAULT NULL,
  `Selling_price` DECIMAL(10,2) UNSIGNED NULL DEFAULT NULL,
  `Units` VARCHAR(45) NULL DEFAULT NULL,
  `Purchase_price` DECIMAL(10,2) UNSIGNED NULL DEFAULT NULL,
  `Provider_idProvider` INT NOT NULL,
  PRIMARY KEY (`idGoods`, `Provider_idProvider`),
  INDEX `fk_Goods_Provider1_idx` (`Provider_idProvider` ASC) VISIBLE,
  CONSTRAINT `fk_Goods_Provider1`
    FOREIGN KEY (`Provider_idProvider`)
    REFERENCES `mydb`.`provider` (`idProvider`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `mydb`.`sales`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`sales` (
  `idSales` INT NOT NULL AUTO_INCREMENT,
  `Date_of_sale` DATETIME NULL DEFAULT NULL,
  `Cash_transactions_idCash_transactions` INT NOT NULL,
  `Employees_idEmployees` INT NOT NULL,
  PRIMARY KEY (`idSales`, `Cash_transactions_idCash_transactions`, `Employees_idEmployees`),
  INDEX `fk_Sales_Cash transactions1_idx` (`Cash_transactions_idCash_transactions` ASC) VISIBLE,
  INDEX `fk_Sales_Employees1_idx` (`Employees_idEmployees` ASC) VISIBLE,
  CONSTRAINT `fk_Sales_Cash transactions1`
    FOREIGN KEY (`Cash_transactions_idCash_transactions`)
    REFERENCES `mydb`.`cash_transactions` (`idCash_transactions`),
  CONSTRAINT `fk_Sales_Employees1`
    FOREIGN KEY (`Employees_idEmployees`)
    REFERENCES `mydb`.`employee` (`idEmployees`))
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `mydb`.`product_sale`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`product_sale` (
  `Quantity` INT NULL DEFAULT NULL,
  `Goods_idGoods` INT NULL DEFAULT NULL,
  `Sales_idSales` INT NULL DEFAULT NULL,
  INDEX `fk_Product sale_Goods1_idx` (`Goods_idGoods` ASC) VISIBLE,
  INDEX `fk_Product sale_Sales1_idx` (`Sales_idSales` ASC) VISIBLE,
  CONSTRAINT `fk_Product sale_Goods1`
    FOREIGN KEY (`Goods_idGoods`)
    REFERENCES `mydb`.`goods` (`idGoods`),
  CONSTRAINT `fk_Product sale_Sales1`
    FOREIGN KEY (`Sales_idSales`)
    REFERENCES `mydb`.`sales` (`idSales`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `mydb`.`purchases`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`purchases` (
  `idPurchases` INT NOT NULL AUTO_INCREMENT,
  `Purchase_date` DATETIME NULL DEFAULT NULL,
  `Completion_status` TINYINT(1) NULL DEFAULT NULL,
  `Cash_transactions_idCash_transactions` INT NOT NULL,
  PRIMARY KEY (`idPurchases`, `Cash_transactions_idCash_transactions`),
  INDEX `fk_Purchases_Cash transactions1_idx` (`Cash_transactions_idCash_transactions` ASC) VISIBLE,
  CONSTRAINT `fk_Purchases_Cash transactions1`
    FOREIGN KEY (`Cash_transactions_idCash_transactions`)
    REFERENCES `mydb`.`cash_transactions` (`idCash_transactions`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `mydb`.`purchase_item`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`purchase_item` (
  `Quantity` INT NULL DEFAULT NULL,
  `Goods_idGoods` INT NULL DEFAULT NULL,
  `Purchases_idPurchases` INT NULL DEFAULT NULL,
  INDEX `fk_Purchase_item_Goods1_idx` (`Goods_idGoods` ASC) VISIBLE,
  INDEX `fk_purchase_item_purchases1_idx` (`Purchases_idPurchases` ASC) INVISIBLE,
  CONSTRAINT `fk_Purchase_item_Goods2`
    FOREIGN KEY (`Goods_idGoods`)
    REFERENCES `mydb`.`goods` (`idGoods`),
  CONSTRAINT `fk_purchase_item_purchases1`
    FOREIGN KEY (`Purchases_idPurchases`)
    REFERENCES `mydb`.`purchases` (`idPurchases`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
