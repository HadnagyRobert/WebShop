using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBQueries
    {
        public static readonly string Connection = "Server=studmysql01.fhict.local;Uid=dbi497144;Database=dbi497144;Pwd=1207;";

    #region Product

        public static readonly string CreateProduct = "INSERT INTO products (name,price,unit,description,image,categoryId,active) VALUES(@name,@price,@unit,@description,@image,@categoryId,@active)";
        public static readonly string UpdateProduct = "UPDATE products SET name = @name, price = @price, unit = @unit, description = @description, image = @image, active = @active, categoryId = @categoryId WHERE id = @id";
        public static readonly string CheckProductName = "SELECT name FROM products WHERE name = @name";
        public static readonly string GetAllProducts = "SELECT p.id, p.name, p.price, p.unit, p.description, p.image, p.active,s.id as categoryId, c.name as categoryName, c.id as subcategoryId FROM products as p INNER JOIN category as c on p.categoryId = c.id INNER JOIN category as s on c.parentCategory = s.id";
        public static readonly string GetAllActiveProducts = "SELECT p.id, p.name, p.price, p.unit, p.description, p.image, p.active,s.id as categoryId, c.name as categoryName, c.id as subcategoryId FROM products as p INNER JOIN category as c on p.categoryId = c.id INNER JOIN category as s on c.parentCategory = s.id WHERE p.active = 1";
        public static readonly string GetProductByName = "SELECT p.id, p.price, p.unit, p.description, p.image,p.active,s.id as categoryId, c.name as categoryName, c.id as subcategoryId FROM products as p INNER JOIN category as c on p.categoryId = c.id INNER JOIN category as s on c.parentCategory = s.id WHERE p.name = @name";
        
    #endregion

    #region Category

        public static readonly string GetCategorys = "SELECT * FROM category WHERE parentCategory IS NOT NULL";
        public static readonly string GetCategorysNull = "SELECT * FROM category WHERE parentCategory IS NULL";
        public static readonly string GetCategoryByName = "SELECT * FROM category WHERE name = @name";

    #endregion

    #region User

        public static readonly string CreateUser = "INSERT INTO users (username,password,salt,role,email,firstName,lastName) VALUES(@username,@password,@salt,@role,@email,@firstName,@lastName)";
        public static readonly string UpdateUser = "UPDATE users SET username = @username, password = @password, salt = @salt, role = @role, email = @email, firstName = @firstName, lastName = @lastName WHERE id= @id";
        public static readonly string CheckUsername = "SELECT username FROM users WHERE username = @username";
        public static readonly string GetAllUsers = "SELECT * FROM users";
        public static readonly string GetUserByUsername = "SELECT * FROM users WHERE username = @username";
        public static readonly string GetUserById = "SELECT * FROM users WHERE id = @id";

    #endregion

    #region Order

        public static readonly string CreateOrder = "INSERT INTO ordersa (userId, statusId, addressId, pickupId, date) VALUES (@userId, @statusId, @addressId, @pickupId, @date);";
        public static readonly string AddProductToOrder = "INSERT INTO orderrecord (orderId, productId, priceAtTimeOfOrder, quantity) VALUES (@orderId, @productId, @priceAtTimeOfOrder, @quantity);";
        public static readonly string GetOrdersAddress = "SELECT o.id,o.statusId,o.date,a.id as address_id,a.country,a.city,a.postalcode, a.street ,a.number, u.id as user_id,u.username,u.password,u.salt,u.role,u.email,u.firstName,u.lastName FROM ordersa as o inner join address as a on o.addressId = a.id INNER JOIN users as u ON o.userId = u.id WHERE o.addressId IS NOT NULL";
        public static readonly string GetOrdersPickup = "SELECT o.id,o.statusId,o.date, u.id as user_id,u.username,u.password,u.salt,u.role,u.email,u.firstName,u.lastName,p.id as pickup_id,p.country as pickup_country,p.city as pickup_city,p.postalcode as pickup_postalcode,p.street as pickup_street,p.number as pickup_number FROM ordersa as o INNER JOIN users as u ON o.userId = u.id INNER join pickup as p on o.pickupId = p.id WHERE o.pickupId IS NOT NULL";
        public static readonly string GetOrdersAddressByUserId = "SELECT o.id,o.statusId,o.date,a.id as address_id,a.country,a.city,a.postalcode, a.street ,a.number, u.id as user_id,u.username,u.password,u.salt,u.role,u.email,u.firstName,u.lastName FROM ordersa as o inner join address as a on o.addressId = a.id INNER JOIN users as u ON o.userId = u.id WHERE o.userId = @userId";
        public static readonly string GetOrdersPickupByUserId = "SELECT o.id,o.statusId,o.date, u.id as user_id,u.username,u.password,u.salt,u.role,u.email,u.firstName,u.lastName,p.id as pickup_id,p.country as pickup_country,p.city as pickup_city,p.postalcode as pickup_postalcode,p.street as pickup_street,p.number as pickup_number FROM ordersa as o INNER JOIN users as u ON o.userId = u.id INNER join pickup as p on o.pickupId = p.id WHERE o.userId = @userId";
        public static readonly string GetProductsPerOrder = "SELECT o.priceAtTimeOfOrder,o.quantity,o.productId,p.name,p.price,p.unit,p.description,p.image,p.active,s.id AS categoryId, c.name as categoryName, c.id as subcategoryId FROM orderrecord as o INNER JOIN products AS p ON o.productId = p.id INNER JOIN category AS c ON p.categoryId = c.id INNER JOIN category AS s ON c.parentCategory = s.id WHERE o.orderId = @orderId";
        public static readonly string GetOrderDateAddress = "SELECT COUNT(*) as result FROM ordersa WHERE date = @date AND pickupId IS NULL";
        public static readonly string GetOrderDatePickup = "SELECT COUNT(*) as result FROM ordersa WHERE date = @date AND addressId IS NULL";
        public static readonly string UpdateOrderStatus = "UPDATE ordersa SET statusId = @statusId WHERE id = @id";
        public static readonly string GetOrderByIdPickup = "SELECT o.statusId,o.date, u.id as user_id,u.username,u.password,u.salt,u.role,u.email,u.firstName,u.lastName,p.id as pickup_id,p.country as pickup_country,p.city as pickup_city,p.postalcode as pickup_postalcode,p.street as pickup_street,p.number as pickup_number FROM ordersa as o INNER JOIN users as u ON o.userId = u.id INNER join pickup as p on o.pickupId = p.id WHERE o.id = @orderId";
        public static readonly string GetOrderByIdAddress = "SELECT o.statusId,o.date,a.id as address_id,a.country,a.city,a.postalcode, a.street ,a.number, u.id as user_id,u.username,u.password,u.salt,u.role,u.email,u.firstName,u.lastName FROM ordersa as o inner join address as a on o.addressId = a.id INNER JOIN users as u ON o.userId = u.id WHERE o.id = @orderId";

    #endregion

    #region Address

        public static readonly string CreateAddress = "INSERT INTO address (country, city, postalcode, street, number) VALUES (@country, @city, @postalcode, @street, @number)";
        public static readonly string GetAddress = "SELECT id FROM address WHERE (country = @country AND city = @city AND postalcode = @postalcode AND street = @street AND number = @number);";

    #endregion

    #region Pickup

        public static readonly string GetAllPickups = "SELECT * FROM pickup";
        public static readonly string GetPickupById = "SELECT * FROM pickup WHERE id = @id";

    #endregion

    }
}