using OnlineShop.Entities;
using OnlineShop.Entities.Enums;
using OnlineShop.Services;
using OnlineShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Web.Controllers
{
    public class HomeController : Controller
    {
        ProductService ProductService;
        CartService CartService;
        SoldProductService SoldProductService;
        ProductViewModel ProductViewModel;
        CartViewModel CartViewModel;
        List<ProductViewModel> ProductViewModelList;
        List<CartViewModel> CartViewModelList;
        CommentService CommentService;
        CartInSoldProductService CartInSoldProductService;
        CommentInProductService CommentInProductService;
        HttpContext context;
        public HomeController()
        {
            ProductService = new ProductService();
            ProductViewModelList = new List<ProductViewModel>();
            CartService = new CartService();
            CartViewModelList = new List<CartViewModel>();
            context = System.Web.HttpContext.Current;
            CartViewModel = new CartViewModel();
            SoldProductService = new SoldProductService();
            CommentService = new CommentService();
            CommentInProductService = new CommentInProductService();
            CartInSoldProductService = new CartInSoldProductService();
        }

        public ActionResult Index()
        {
            List<Product> prodactsList = ProductService.GetProducts();
            foreach (var item in prodactsList)
            {
                ProductViewModel = new ProductViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Picture = item.Picture
                };
                ProductViewModelList.Add(ProductViewModel);
            }
            return View(ProductViewModelList);
        }
        
             public ActionResult SortByBrand(Brand brand)
        {
            if (brand.ToString() != null)
            {
                List<Product> prodactsList = ProductService.GetProducts().Where(x => x.Brand == brand).ToList();
                foreach (var item in prodactsList)
                {
                    ProductViewModel = new ProductViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price,
                        Picture = item.Picture
                    };
                    ProductViewModelList.Add(ProductViewModel);
                }
            }
            return View("Index", ProductViewModelList);
        }

        public ActionResult SortOfProducts(Category category)
        {
            if (category.ToString() != null)
            {
                List<Product> prodactsList = ProductService.GetProducts().Where(x => x.KindOfGoods == category).ToList();
                foreach (var item in prodactsList)
                {
                    ProductViewModel = new ProductViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price,
                        Picture = item.Picture
                    };
                    ProductViewModelList.Add(ProductViewModel);
                }
            }
            return View("Index", ProductViewModelList);
        }

        public ActionResult Contact()
        {
            // contact
            return View();
        }

        public ActionResult ProductDetails(string id)
        {

            var commentInProductList = CommentInProductService.GetCommentInProduct().Where(x => x.ProductId == id).ToList();
            var commentList = CommentService.GetComments();
            var comments = new List<Comment>();
            foreach (var item in commentInProductList)
            {
                comments.AddRange(commentList.Where(x => x.Id == item.CommentId).ToList());
            }
            var product = ProductService.GetProductByID(id);
            ProductViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Picture = product.Picture,
                Description = product.Description,
                KindOfGoods = product.KindOfGoods,
                Brand = product.Brand,
                Comments = comments
            };
            return View(ProductViewModel);
        }

        public ActionResult AddComment(ProductViewModel model)
        {
            Comment comment = new Comment
            {
                UserName = model.UserName,
                Email = model.Email,
                Text = model.CommentText
            };
            CommentService.AddNewComment(comment);

            var commentInProduct = new CommentInProduct();
            commentInProduct.ProductId = model.Id;
            commentInProduct.CommentId = comment.Id;
            CommentInProductService.AddNewCommentInProduct(commentInProduct);

            var commentInProductList = CommentInProductService.GetCommentInProduct().Where(x => x.ProductId == model.Id).ToList();
            var commentList = CommentService.GetComments();
            var comments = new List<Comment>();
            foreach (var item in commentInProductList)
            {
                comments.AddRange(commentList.Where(x => x.Id == item.CommentId).ToList());
            }
            var product = ProductService.GetProductByID(model.Id);
            ProductViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Picture = product.Picture,
                Description = product.Description,
                KindOfGoods = product.KindOfGoods,
                Brand = product.Brand,
                Comments = comments
            };
            return PartialView("AddComment", ProductViewModel);
        }

        public ActionResult Cart()
        {
            List<Cart> cart = CartService.GetCarts().Where(x => x.CookiesValue == context.Request.Cookies.Get("id").Value).ToList();
            foreach (var item in cart)
            {
                var product = ProductService.GetProductByID(item.ProductId);
                CartViewModel = new CartViewModel
                {
                    Id = item.Id,
                    CookiesValue = item.CookiesValue,
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Picture = product.Picture,
                    Quantity = item.Quantity,
                    TotalPriceOfProduct = item.Quantity * product.Price
                };
                CartViewModel.CartTotalPrice += CartViewModel.TotalPriceOfProduct;
                CartViewModelList.Add(CartViewModel);
            }
            return View(CartViewModelList);
        }

        public ActionResult AddToCart(string id, int Quantity)
        {

            Cart cart;
            string cookiesValue;
            if (context.Request.Cookies.Keys.Count == 0)
            {
                cookiesValue = Response.Cookies["id"].Value = GetRandomString();
                //     HttpCookie = new HttpCookie();
                //   HttpCookie.Expires = DateTime.Now.AddHours(1);  
            }

            cookiesValue = context.Request.Cookies.Get("id").Value;
            cart = new Cart
            {
                ProductId = id,
                Quantity = Quantity,
                CookiesValue = cookiesValue
            };
            CartService.AddNewCart(cart);
            return RedirectToAction("Index"); // ajax or page update
        }

        public ActionResult DeleteProductFromCart(string id)
        {
            CartService.DeleteProductFromCart(id);
            List<Cart> cart = CartService.GetCarts().Where(x => x.CookiesValue == context.Request.Cookies.Get("id").Value).ToList();
            foreach (var item in cart)
            {
                var product = ProductService.GetProductByID(item.ProductId);
                CartViewModel = new CartViewModel
                {
                    Id = item.Id,
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Picture = product.Picture,
                    Quantity = item.Quantity,
                    TotalPriceOfProduct = item.Quantity * product.Price
                };
                CartViewModel.CartTotalPrice += CartViewModel.TotalPriceOfProduct;
                CartViewModelList.Add(CartViewModel);
            }

            return PartialView("ListOfProduct", CartViewModelList);
        }


        public ActionResult SoldProduct(string cookiesValue, string name, string lastName, string email, string number, string address)
        {
            List<Cart> cart = CartService.GetCarts().Where(x => x.CookiesValue == cookiesValue).ToList();
            SoldProduct soldProduct = new SoldProduct
            {
                UserName = name,
                UserLastName = lastName,
                PhoneNumber = number,
                Email = email,
                Address = address
            };
            SoldProductService.AddNewSoldProduct(soldProduct);

            var cartInSoldProduct = new CartInSoldProduct
            {
                CartId = cart.Select(x => x.Id).ToList(),
                SoldProductId = soldProduct.Id
            };
            CartInSoldProductService.AddNewCartInSoldProduct(cartInSoldProduct);
            return View();
        }

        public string GetRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var randomString = new String(stringChars);
            return randomString;
        }



    }
}