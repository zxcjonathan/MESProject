using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MESProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MESProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var workOrders = await _context.WorkOrders.ToListAsync();
        return View(workOrders);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

    // GET: /Home/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Home/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(WorkOrder workOrder)
    {
        // 檢查模型狀態是否有效
        if (ModelState.IsValid)
        {
            // 賦予非表單欄位的值
            workOrder.Status = "待生產";
            workOrder.CreatedDate = DateTime.Now;

            _context.Add(workOrder);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "工單已成功創建！";
            return RedirectToAction(nameof(Index));
        }
        // 如果模型驗證失敗，返回檢視頁面並顯示錯誤
        return View(workOrder);
    }

    // GET: /Home/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var workOrder = await _context.WorkOrders.FindAsync(id);
        if (workOrder == null)
        {
            return NotFound();
        }
        return View(workOrder);
    }

    // POST: /Home/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("WorkOrderId,ProductCode,Quantity,Status,PlannedStartTime,ActualStartTime,CompletionTime,ProductionLine,Notes")] WorkOrder workOrder)
    {
        if (id != workOrder.WorkOrderId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                // 1. 從資料庫中讀取原始工單資料
                var originalWorkOrder = await _context.WorkOrders.AsNoTracking().FirstOrDefaultAsync(m => m.WorkOrderId == id);
                if (originalWorkOrder == null)
                {
                    return NotFound();
                }

                // 2. 將原始的 CreatedDate 賦予給新的工單物件
                workOrder.CreatedDate = originalWorkOrder.CreatedDate;

                // 3. 更新工單
                _context.Update(workOrder);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "工單已成功更新！";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkOrderExists(workOrder.WorkOrderId))
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
        return View(workOrder);
    }

    // GET: /Home/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var workOrder = await _context.WorkOrders
            .FirstOrDefaultAsync(m => m.WorkOrderId == id);
        if (workOrder == null)
        {
            return NotFound();
        }

        return View(workOrder);
    }

    // GET: /Home/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var workOrder = await _context.WorkOrders
            .FirstOrDefaultAsync(m => m.WorkOrderId == id);
        if (workOrder == null)
        {
            return NotFound();
        }

        return View(workOrder);
    }

    // POST: /Home/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var workOrder = await _context.WorkOrders.FindAsync(id);
        if (workOrder != null)
        {
            _context.WorkOrders.Remove(workOrder);
        }

        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "工單已成功刪除！";
        return RedirectToAction(nameof(Index));
    }

    private bool WorkOrderExists(int id)
    {
        return _context.WorkOrders.Any(e => e.WorkOrderId == id);
    }
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}