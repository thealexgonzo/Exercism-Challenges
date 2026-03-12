static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string message = $"{name} - {department?.ToUpper() ?? "OWNER"}";
        return id == null ? message : $"[{id}] - " + message;
    }
}
