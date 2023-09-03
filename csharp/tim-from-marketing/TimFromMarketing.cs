using System;

static class Badge
{
    private static string formatDept(string? department)
        => department?.ToUpper() ?? "OWNER";
    public static string Print(int? id, string name, string? department)
        => id.HasValue
        ? Print(id, name, department)
        : Print(name, department);
    public static string Print(int id, string name, string? department)
        => $"[{id}] - {name} - {formatDept(department)}";
    public static string Print(string name, string? department)
        => $"{name} - {formatDept(department)}";
}
