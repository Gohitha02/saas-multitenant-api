using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaaS.MultiTenant.Api.Data;
using SaaS.MultiTenant.Api.Models;
using SaaS.MultiTenant.Api.Tenancy;

namespace SaaS.MultiTenant.Api.Controllers;

[ApiController]
[Route("api/projects")]
public sealed class ProjectsController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly TenantContext _tenant;

    public ProjectsController(AppDbContext db, TenantContext tenant)
    {
        _db = db;
        _tenant = tenant;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var tenantId = _tenant.CurrentTenant?.Id ?? "unknown";
        var items = await _db.Projects.AsNoTracking().OrderByDescending(x => x.Id).ToListAsync();
        return Ok(new { tenant = tenantId, data = items });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProjectItem input)
    {
        if (string.IsNullOrWhiteSpace(input.Name))
            return BadRequest("Name is required");

        var entity = new ProjectItem { Name = input.Name.Trim() };
        _db.Projects.Add(entity);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
    }
}
