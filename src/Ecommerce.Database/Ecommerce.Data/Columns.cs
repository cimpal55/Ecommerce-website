namespace Ecommerce.Data
{
    public static class Columns
    {
        public static class Countries
        {
            public const string Id = "Id";
            public const string Name = "Name";
            public const string Created = "Created";
        }
        public static class Users
        {
            public const string Id = "Id";
            public const string Email = "Email";
            public const string PasswordHash = "PasswordHash";
            public const string PasswordSalt = "PasswordSalt";
            public const string PhoneNumber = "PhoneNumber";
            public const string Address = "Address";
            public const string Role = "Role";
            public const string Created = "Created";
        }
        public static class UserAddresses
        {
            public const string Id = "Id";
            public const string UserId = "UserId";
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
            public const string Street = "Street";
            public const string City = "City";
            public const string State = "State";
            public const string Zip = "Zip";
            public const string CountryId = "CountryId";
            public const string Created = "Created";
        }
        public static class ProductTypes
        {
            public const string Id = "Id";
            public const string Name = "Name";
            public const string Created = "Created";
        }
        public static class Categories
        {
            public const string Id = "Id";
            public const string Name = "Name";
            public const string Visible = "Visible";
            public const string Created = "Created";
        }
        public static class Products
        {
            public const string Id = "Id";
            public const string Title = "Title";
            public const string Description = "Description";
            public const string ImageUrl = "ImageUrl";
            public const string CategoryId = "CategoryId";
            public const string Featured = "Featured";
            public const string Visible = "Visible";
            public const string Created = "Created";
        }
        public static class ProductVariants
        {
            public const string Id = "Id";
            public const string ProductId = "ProductId";
            public const string ProductTypeId = "ProductTypeId";
            public const string Price = "Price";
            public const string OriginalPrice = "OriginalPrice";
            public const string Visible = "Visible";
            public const string Created = "Created";
        }
        public static class Images
        {
            public const string Id = "Id";
            public const string Data = "Data";
            public const string ProductId = "ProductId";
            public const string Created = "Created";
        }
        public static class CartItems
        {
            public const string Id = "Id";
            public const string UserId = "UserId";
            public const string ProductId = "ProductId";
            public const string ProductTypeId = "ProductTypeId";
            public const string Quantity = "Quantity";
            public const string Created = "Created";
        }
        public static class Orders
        {
            public const string Id = "Id";
            public const string UserId = "UserId";
            public const string OrderDate = "OrderDate";
            public const string TotalPrice = "TotalPrice";
            public const string Created = "Created";
        }
        public static class OrderItems
        {
            public const string Id = "Id";
            public const string OrderId = "OrderId";
            public const string ProductId = "ProductId";
            public const string ProductTypeId = "ProductTypeId";
            public const string Quantity = "Quantity";
            public const string TotalPrice = "TotalPrice";
            public const string Created = "Created";
        }

    }
}
    