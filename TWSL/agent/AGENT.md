# C# Coding Agent Instructions

## 1. Mục tiêu
Agent có nhiệm vụ hỗ trợ:
- Viết, sửa, tối ưu code C#
- Tuân thủ chuẩn .NET hiện đại
- Dễ đọc, dễ test, dễ mở rộng

Ưu tiên **tính đúng, rõ ràng và an toàn** hơn là code phức tạp.

---

## 2. Môi trường & Công nghệ
- Ngôn ngữ: **C#**
- Nền tảng: **.NET 6+ (ưu tiên .NET 8 nếu không yêu cầu khác)**
- IDE phổ biến: Visual Studio / VS Code
- Kiểu dự án:
  - Console
  - ASP.NET Core Web API
  - Worker Service
  - Class Library

---

## 3. Quy ước Code (Coding Conventions)

### 3.1 Naming
- Class / Record / Struct: `PascalCase`
- Method: `PascalCase`
- Property: `PascalCase`
- Local variable / parameter: `camelCase`
- Interface: bắt đầu bằng `I`
- Async method: hậu tố `Async`

```csharp
public async Task<UserDto> GetUserAsync(Guid userId)
```

---

### 3.2 Formatting
- Mỗi class 1 file
- Không viết logic phức tạp trong constructor
- Ưu tiên code rõ ràng hơn rút gọn

---

## 4. Nguyên tắc Thiết kế
- SOLID
- Dependency Injection
- Controller không chứa business logic
- Service xử lý nghiệp vụ
- Repository xử lý dữ liệu

Luồng chuẩn:
```
Controller → Service → Repository
```

---

## 5. Async & Performance
- Luôn dùng `async/await` cho I/O
- Tránh `.Result`, `.Wait()`
- Truyền `CancellationToken` cho tác vụ dài

---

## 6. Error Handling & Logging
- Không catch exception rỗng
- Bắt exception cụ thể
- Sử dụng `ILogger<T>`

```csharp
try
{
    await service.ProcessAsync();
}
catch (InvalidOperationException ex)
{
    logger.LogWarning(ex, "Invalid operation");
    throw;
}
```

---

## 7. Testing
- Framework: xUnit / NUnit
- Mô hình: AAA (Arrange – Act – Assert)
- Test Service là chính

---

## 8. Không nên làm
- Hard-code connection string
- Logic nghiệp vụ trong Controller
- Bỏ qua null-check
- Bỏ qua cancellation token

---

## 9. Ưu tiên khi Agent trả lời
1. Code đúng
2. Dễ đọc
3. Theo chuẩn C#
4. Có ví dụ
5. Giải thích ngắn gọn

---

## 10. Ngôn ngữ
- Trả lời bằng **tiếng Việt**
- Giữ nguyên thuật ngữ kỹ thuật tiếng Anh

---

## 11. Ghi chú
- Nếu yêu cầu thiếu thông tin, đưa ra giả định hợp lý và nêu rõ

---

**End of Instructions**
