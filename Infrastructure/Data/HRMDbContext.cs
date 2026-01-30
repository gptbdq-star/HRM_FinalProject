using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class HRMDbContext : DbContext
{
    public HRMDbContext(DbContextOptions<HRMDbContext> options)
        : base(options)
    {
    }

    // --- 1. CÁC BẢNG CŨ (CORE) ---
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Position> Positions => Set<Position>();
    public DbSet<User> Users => Set<User>();

    // --- 2. CÁC BẢNG MỚI (MỞ RỘNG) ---
    // Nhân sự & Hợp đồng
    public DbSet<LaborContract> LaborContracts => Set<LaborContract>();

    // Chấm công & Ca làm việc
    public DbSet<WorkShift> WorkShifts => Set<WorkShift>();
    public DbSet<Timesheet> Timesheets => Set<Timesheet>();

    // Nghỉ phép
    public DbSet<LeaveType> LeaveTypes => Set<LeaveType>();
    public DbSet<LeaveRequest> LeaveRequests => Set<LeaveRequest>();

    // Lương & Thưởng/Phạt
    public DbSet<RewardDiscipline> RewardDisciplines => Set<RewardDiscipline>();
    public DbSet<Payslip> Payslips => Set<Payslip>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // --- CẤU HÌNH EMPLOYEE ---
        modelBuilder.Entity<Employee>()
            .HasIndex(e => e.EmployeeCode)
            .IsUnique();

        // [QUAN TRỌNG] Fix lỗi xóa nhầm: Chặn xóa Phòng ban/Chức vụ nếu đang có nhân viên
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany()
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Position)
            .WithMany()
            .HasForeignKey(e => e.PositionId)
            .OnDelete(DeleteBehavior.Restrict);

        // --- CẤU HÌNH DEPARTMENT (Đệ quy) ---
        modelBuilder.Entity<Department>()
            .HasOne(d => d.ParentDepartment)
            .WithMany(d => d.SubDepartments)
            .HasForeignKey(d => d.ParentDepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        // --- CẤU HÌNH CÁC BẢNG MỚI ---

        // 1. Hợp đồng lao động: Nếu xóa Nhân viên -> Hợp đồng bay theo (Cascade OK)
        modelBuilder.Entity<LaborContract>()
            .HasOne(x => x.Employee)
            .WithMany()
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        // 2. Chấm công: Đã đi làm (có dữ liệu chấm công) -> KHÔNG ĐƯỢC xóa nhân viên (Restrict)
        modelBuilder.Entity<Timesheet>()
            .HasOne(x => x.Employee)
            .WithMany()
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        // 3. Bảng lương: Đã nhận lương (liên quan tài chính) -> KHÔNG ĐƯỢC xóa nhân viên (Restrict)
        modelBuilder.Entity<Payslip>()
            .HasOne(x => x.Employee)
            .WithMany()
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        // 4. Thưởng phạt: Liên quan tiền nong -> Nên giữ lại (Restrict)
        modelBuilder.Entity<RewardDiscipline>()
            .HasOne(x => x.Employee)
            .WithMany()
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Employee)
            .WithOne(e => e.User)
            .HasForeignKey<User>(u => u.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
        // USER - ROLE
        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        // ROLE - PERMISSION (N-N)
        modelBuilder.Entity<RolePermission>()
            .HasKey(rp => new { rp.RoleId, rp.PermissionId });

        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Role)
            .WithMany(r => r.RolePermissions)
            .HasForeignKey(rp => rp.RoleId);

        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Permission)
            .WithMany(p => p.RolePermissions)
            .HasForeignKey(rp => rp.PermissionId);



        base.OnModelCreating(modelBuilder);
    }
}