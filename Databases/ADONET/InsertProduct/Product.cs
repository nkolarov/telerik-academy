// ********************************
// <copyright file="Product.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace InsertProduct
{
    using System;

    /// <summary>
    /// Represents a Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or Sets the Product Id.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or Sets the Product Name.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or Sets the Supplier ID.
        /// </summary>
        public int? SupplierID { get; set; }

        /// <summary>
        /// Gets or Sets the Category ID.
        /// </summary>
        public int? CategoryID { get; set; }

        /// <summary>
        /// Gets or Sets the Quantity Per Unit.
        /// </summary>
        public string QuantityPerUnit { get; set; }

        /// <summary>
        /// Gets or Sets the Unit Price.
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Gets or Sets the Units In Stock.
        /// </summary>
        public int? UnitsInStock { get; set; }

        /// <summary>
        /// Gets or Sets the Units On Order.
        /// </summary>
        public int? UnitsOnOrder { get; set; }

        /// <summary>
        /// Gets or Sets the Reorder Level.
        /// </summary>
        public int? ReorderLevel { get; set; }

        /// <summary>
        /// Gets or Sets the is discounted.
        /// </summary>
        public bool Discontinued { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="productId">Product ID.</param>
        /// <param name="productName">Product Name.</param>
        /// <param name="quantityPerUnit">Quantity per unit.</param>
        /// <param name="discontinued">Is discounted.</param>
        /// <param name="supplierID">Supplier id.</param>
        /// <param name="categoryID">Category id.</param>
        /// <param name="unitPrice">Unit price.</param>
        /// <param name="unitsInStock">Units in stock.</param>
        /// <param name="unitsOnOrder">Units on order.</param>
        /// <param name="reorderLevel">Reorder level.</param>
        public Product(
            int productId,
            string productName,
            string quantityPerUnit,
            bool discontinued,
            int? supplierID = null,
            int? categoryID = null,
            decimal? unitPrice = null,
            int? unitsInStock = null,
            int? unitsOnOrder = null,
            int? reorderLevel = null
            )
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.SupplierID = supplierID;
            this.CategoryID = categoryID;
            this.QuantityPerUnit = quantityPerUnit;
            this.UnitPrice = unitPrice;
            this.UnitsInStock = unitsInStock;
            this.UnitsOnOrder = unitsOnOrder;
            this.ReorderLevel = reorderLevel;
            this.Discontinued = discontinued;
        }
    }
}
