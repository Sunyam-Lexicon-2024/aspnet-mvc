using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Web.Data;
using MVC.Web.Models;

namespace MVC.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index(string selectedCategory, string productName)
        {
            IEnumerable<Product> products;
            if (!string.IsNullOrEmpty(selectedCategory) || !string.IsNullOrEmpty(productName))
            {
                products = await Filter(selectedCategory, productName);
            }
            else
            {
                products = await _context.Product.ToListAsync();
            }

            var productView = products.Select(p => new ProductListViewModel(p));
            var allProducts = _context.Product.ToList();
            var categories = allProducts.Select(p => p.Category).Distinct().ToList();
            ProductListViewModel.Categories = new SelectList(categories);
            return View(productView);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel productViewModel)
        {
            Product? productToCreate = null;
            if (ModelState.IsValid)
            {
                productToCreate = new Product()
                {
                    Name = productViewModel.Name!,
                    Price = productViewModel.Price,
                    Count = productViewModel.Count,
                    Category = productViewModel.Category,
                    Shelf = productViewModel.Shelf!,
                    Description = productViewModel.Description,
                    OrderDate = productViewModel.OrderDate,
                };
                _context.Add(productToCreate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productToCreate);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Price,OrderDate,Category,Shelf,Count,Description")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET : Product/List
        public async Task<IActionResult> List()
        {
            var products = await _context.Product.ToListAsync();

            var productViewModels = products.Select(p => new ProductListViewModel(product: p));

            return View(productViewModels);
        }

        private async Task<IEnumerable<Product>> Filter(string? category, string? name)
        {
            IEnumerable<Product> filteredProducts;
            var products = await _context.Product.ToListAsync();

            if (string.IsNullOrEmpty(category))
            {
                filteredProducts = products.Where(p => p.Name == name).ToList();
            }
            else if (string.IsNullOrEmpty(name))
            {
                filteredProducts = products.Where(p => p.Category == category).ToList();
            }
            else
            {
                filteredProducts = products.Where(p => p.Category == category && p.Name == name).ToList();
            }
            return filteredProducts;
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ID == id);
        }
    }
}
