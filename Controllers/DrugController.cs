using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FptLongChauApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FptLongChauApp.Controllers {
    [Route ("/Drugs")]
    public class DrugController : Controller {
        private readonly ILogger<DrugController> _logger;

        private readonly AppDbContext _context;

        // Key lưu chuỗi json của Cart
        public const string CARTKEY = "cart";

        // Lấy cart từ Session (danh sách CartItem)
        List<CartItem> GetCartItems () {

            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null) {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem> ();
        }

        // Xóa cart khỏi session
        void ClearCart () {
            var session = HttpContext.Session;
            session.Remove (CARTKEY);
        }

        // Lưu Cart (Danh sách CartItem) vào session
        void SaveCartSession (List<CartItem> ls) {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject (ls);
            session.SetString (CARTKEY, jsoncart);
        }


        public DrugController (ILogger<DrugController> logger, AppDbContext context) {
            _logger = logger;
            _context = context;
        }

        // Hiện thị danh sách sản phẩm, có nút chọn đưa vào giỏ hàng
        public IActionResult Index () {
            var Drugs = _context.Drugs.ToList ();
            return View (Drugs);
        }

        /// Thêm sản phẩm vào cart
        [Route ("addcart/{Drugid:int}", Name = "addcart")]
        public IActionResult AddToCart ([FromRoute] int Drugid) {

            var Drug = _context.Drugs
                .Where (p => p.DrugId == Drugid)
                .FirstOrDefault ();

            if (Drug == null)
                return NotFound ("Không có sản phẩm");

            // Xử lý đưa vào Cart ...
            var cart = GetCartItems ();
            var cartitem = cart.Find (p => p.Drug.DrugId == Drugid);
            if (cartitem != null) {
                // Đã tồn tại, tăng thêm 1
                cartitem.Quantity++;
            } else {
                //  Thêm mới
                cart.Add (new CartItem () { Quantity = 1, Drug = Drug });
            }

            // Lưu cart vào Session
            SaveCartSession (cart);
            // Chuyển đến trang hiện thị Cart
            return RedirectToAction (nameof (Cart));
        }



        /// xóa item trong cart
        [Route ("/removecart/{Drugid:int}", Name = "removecart")]
        public IActionResult RemoveCart ([FromRoute] int Drugid) {
            var cart = GetCartItems ();
            var cartitem = cart.Find (p => p.Drug.DrugId == Drugid);
            if (cartitem != null) {
                // Đã tồn tại, tăng thêm 1
                cart.Remove(cartitem);
            } 

            SaveCartSession (cart);
            return RedirectToAction (nameof (Cart));
        }

        /// Cập nhật
        [Route ("/updatecart", Name = "updatecart")]
        [HttpPost]
        public IActionResult UpdateCart ([FromForm] int Drugid, [FromForm] int quantity) {
            // Cập nhật Cart thay đổi số lượng quantity ...
            var cart = GetCartItems ();
            var cartitem = cart.Find (p => p.Drug.DrugId == Drugid);
            if (cartitem != null) {
                // Đã tồn tại, tăng thêm 1
                cartitem.Quantity = quantity;
            } 
            SaveCartSession (cart);
            // Trả về mã thành công (không có nội dung gì - chỉ để Ajax gọi)
            return Ok();
        }

        // Hiện thị giỏ hàng
        [Route ("/cart", Name = "cart")]
        public IActionResult Cart () {
            return View (GetCartItems());
        }

        [Route ("/checkout")]
        public IActionResult CheckOut ([FromForm] string email, [FromForm] string address) {
            
            // Xử lý khi đặt hàng
            var cart = GetCartItems();
            ViewData["email"] = email;
            ViewData["address"] = address;
            ViewData["cart"] = cart;

            if (!string.IsNullOrEmpty(email)) {
                // hãy tạo cấu trúc db lưu lại đơn hàng và xóa cart khỏi session

                ClearCart();
                RedirectToAction(nameof(Index));
            }

            return View();
        }

    }
}