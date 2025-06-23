//using Microsoft.AspNetCore.Mvc;
//using System.ComponentModel.DataAnnotations;

//namespace E_Commerce.Controllers;

//[Route("api/[controller]")] // BaseURL/api/Products
//[ApiController]
//public class ProductsController : ControllerBase
//{
//    #region Dummy APIs

//    [HttpGet("{id:int}")]
//    public ActionResult<Product> Get(int id)
//    {
//        return new Product() { Id = id };
//    }
//    [HttpGet]
//    public ActionResult<Product> GetAll([FromQuery] Product product)
//    {
//        return new Product() { Id = 100 };
//    }
//    [HttpPost]
//    public ActionResult<Product> Add(int id)
//    {
//        return new Product() { Id = 100 };
//    }
//    [HttpPut]
//    public ActionResult<Product> Update(int id)
//    {
//        return new Product() { Id = 100 };
//    }
//    [HttpDelete]
//    public ActionResult<Product> Delete(int id)
//    {
//        return new Product() { Id = 100 };
//    } 
//    #endregion
//}
//public class Product
//{
//    [Range(1,2)]
//    public int Id { get; set; }
//    [Required]
//    public string Name { get; set; } = string.Empty;
//}
