namespace TodoApp.Contracts;

public record UpdateTodoReqest(string Title, string Description, bool IsDone);