
using SqliteWasmHelper;
using TaskApp.Data;

public class TaskAppService
{
    // Sqlite Wasm Factory For DI Service
    private readonly ISqliteWasmDbContextFactory<SqliteDbContext>? _sqliteDbContextFactory;

    //Logger for DI Service
    private readonly ILogger<TaskApp.App> _Logger;

    //Event Handler For Updating UI after DB Change
    public event EventHandler<string>? TaskComponetMessages;

    public TaskAppService(
        ISqliteWasmDbContextFactory<SqliteDbContext> _factory,
        ILogger<TaskApp.App> logger)
    {
        _sqliteDbContextFactory = _factory;
        _Logger = logger;
    }

    //Setting Event Args For TaskComponetMessages
    protected virtual void SetComponentMessage(object e, string args)
    {
        if (args != null)
        {
            TaskComponetMessages!(this, args);
        }
    }
    //Adds New Task with SqliteDbContextFactory
    public async Task<int> AddNewTask(TaskModel model)
    {
        try
        {
            using var SqliteContextInstance = await _sqliteDbContextFactory!.CreateDbContextAsync();

            await SqliteContextInstance!.AddAsync<TaskModel>(model);
            var Response = await SqliteContextInstance.SaveChangesAsync();
            _Logger.LogInformation("AddNewTask() fired at {Time}", DateTime.UtcNow);

            return Response;
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    //Edit Task with SqliteDbContextFactory

    public async Task<int> EditTask(TaskModel model)
    {
        try
        {
            using var SqliteContextInstance = await _sqliteDbContextFactory!.CreateDbContextAsync();

            var Result = SqliteContextInstance.taskModels.Where(x => x.TaskID == model.TaskID).Any();

            if (Result)
            {
                SqliteContextInstance!.Update(model);

                var Response = await SqliteContextInstance.SaveChangesAsync();

                // Event for Updating the Parent UI
                SetComponentMessage(this, "Event From Edit Task");

                _Logger.LogInformation("EditTask() fired at {Time}", DateTime.UtcNow);

                return Response;
            }
            else
            {
                return 0;
            }

        }
        catch (System.Exception)
        {

            throw;
        }


    }

    //Delete Task with SqliteDbContextFactory

    public async Task<int> DeleteTask(TaskModel model)
    {
        try
        {
            using var SqliteContextInstance = await _sqliteDbContextFactory!.CreateDbContextAsync();

            var Result = SqliteContextInstance.taskModels.Where(x => x.TaskID == model.TaskID).Any();

            if (Result)
            {
                SqliteContextInstance!.Remove(model);

                var Response = await SqliteContextInstance.SaveChangesAsync();
                //Call Event for Updating the Parent UI
                SetComponentMessage(this, "Event From Delete Task");

                _Logger.LogInformation("DeleteTask() fired at {Time}", DateTime.UtcNow);

                return Response;

            }
            else
            {
                return 0;

            }

        }
        catch (System.Exception)
        {

            throw;
        }

    }

    //Load All Task with SqliteDbContextFactory
    public async Task<List<TaskModel>> GetAllTasks()
    {
        try
        {
            using var SqliteContextInstance = await _sqliteDbContextFactory!.CreateDbContextAsync();

            var Result = SqliteContextInstance!.taskModels!.ToList<TaskModel>();

            return Result;
        }
        catch (System.Exception)
        {

            throw;
        }


    }
}