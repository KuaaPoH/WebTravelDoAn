using WebTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Harmic.Controllers
{
    public class BlogController : Controller
    {
        private readonly TravelContext _context;

        public BlogController(TravelContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/blog/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbBlogs == null)
            {
                return NotFound();
            }

            var blog = await _context.TbBlogs
                .FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }

            ViewBag.BlogId = id;
            ViewBag.blogComment = _context.TbBlogComments.Where(i => i.BlogId == id).ToList();
            ViewBag.blogRelated = _context.TbBlogs.
                Where(i => i.BlogId != id && i.CategoryId == blog.CategoryId).Take(3).
                OrderByDescending(i => i.BlogId).ToList();

            return View(blog);
        }
        [HttpPost]
        public async Task<IActionResult> Create(int blogId, string name, string phone, string email, string message)
        {
            try
            {
                // Kiểm tra xem blogId có hợp lệ không
                var blog = await _context.TbBlogs.FirstOrDefaultAsync(b => b.BlogId == blogId);
                if (blog == null)
                {
                    return Json(new { status = false, message = "Blog không tồn tại." });
                }

                // Tạo đối tượng bình luận mới
                TbBlogComment contact = new TbBlogComment
                {
                    BlogId = blogId,
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Detail = message,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    Image = "avatar.jpg", // Ảnh mặc định
                };

                // Thêm vào cơ sở dữ liệu
                _context.Add(contact);
                await _context.SaveChangesAsync();

                // Trả về JSON bao gồm bình luận mới
                return Json(new
                {
                    status = true,
                    message = "Bình luận đã gửi thành công!",
                    comment = new
                    {
                        name = contact.Name,
                        createdDate = contact.CreatedDate?.ToString("dd/MM/yyyy"),
                        detail = contact.Detail,
                        image = contact.Image
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = "Có lỗi xảy ra: " + ex.Message });
            }
        }
    }
}