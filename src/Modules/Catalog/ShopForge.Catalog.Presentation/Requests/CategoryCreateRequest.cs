namespace ShopForge.Catalog.Presentation.Requests;

public sealed record CategoryCreateRequest(string Name, string Description, bool IsActive, Guid? ParentId);