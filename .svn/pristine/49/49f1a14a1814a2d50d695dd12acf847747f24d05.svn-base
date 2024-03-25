using Admin.NET.Application.Const;
using Admin.NET.Application.Service;
using Admin.NET.Core.Entity.WFH_Entity;
using Furion.DatabaseAccessor;
using Furion.JsonSerialization;
using Microsoft.AspNetCore.Http;

namespace Admin.NET.Application;
/// <summary>
/// 任务表服务
/// </summary>
[ApiDescriptionSettings(ApplicationConst.ProjectManagement, Order = 100)]
public class AssignmentService : IDynamicApiController, ITransient
{
    private readonly SqlSugarRepository<Assignment> _rep;
    private readonly SqlSugarRepository<ProjectData> _projectDataRep;
    private readonly SqlSugarRepository<UploadSinglechip> _uploadSinglechipRep;//单片机
    private readonly SqlSugarRepository<GoodsInformation> _goodsInformationRep;//商品资料表服务
    private readonly SqlSugarRepository<BomMaster> _bomMasterRep;//bom主表
    private readonly SqlSugarRepository<BomDetails> _bomDetailsRep;//bom表明细表
    private readonly SqlSugarRepository<BomDetailsCopy> _bomDetailsCopyRep;//bom表明细表副本
    private readonly SqlSugarRepository<Layout> _layoutRep;//硬件
    private readonly SqlSugarRepository<UpperComputerProgram> _upperComputerProgramRep;//上位机
    private readonly UserManager _userManagerRep;
    private readonly FileService _fileServiceRep;//上传文件接口
    private readonly IJsonSerializerProvider _jsonSerializerRep;//字段序列化
    public AssignmentService(SqlSugarRepository<Assignment> rep,
        FileService fileServiceRep,
        UserManager userManagerRep,
        SqlSugarRepository<ProjectData> projectDataRep,
        SqlSugarRepository<UploadSinglechip> uploadSinglechipRep,
        SqlSugarRepository<GoodsInformation> goodsInformationRep,
        SqlSugarRepository<BomMaster> bomMasterRep,
        SqlSugarRepository<BomDetails> bomDetailsRep,
        SqlSugarRepository<BomDetailsCopy> bomDetailsCopyRep,
        SqlSugarRepository<Layout> layoutRep,
        SqlSugarRepository<UpperComputerProgram> upperComputerProgramRep,
        IJsonSerializerProvider jsonSerializerRep
        )
    {
        _rep = rep;
        _userManagerRep = userManagerRep;
        _projectDataRep = projectDataRep;
        _jsonSerializerRep = jsonSerializerRep;
        _fileServiceRep = fileServiceRep;
        _uploadSinglechipRep = uploadSinglechipRep;
        _goodsInformationRep=goodsInformationRep;
        _bomMasterRep = bomMasterRep;
        _bomDetailsRep=bomDetailsRep;
        _bomDetailsCopyRep=bomDetailsCopyRep;
        _layoutRep=layoutRep;
        _upperComputerProgramRep=upperComputerProgramRep;
    }

    /// <summary>
    /// 分页查询任务表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Page")]
    public async Task<SqlSugarPagedList<AssignmentOutput>> Page(AssignmentInput input)
    {
        var query = _rep.AsQueryable()
            .WhereIF(!string.IsNullOrWhiteSpace(input.SearchKey), u =>
                u.MeMo.Contains(input.SearchKey.Trim())
                || u.PredecessorTaskName.Contains(input.SearchKey.Trim())
                || u.AssignmentName.Contains(input.SearchKey.Trim())
                || u.Sno.Contains(input.SearchKey.Trim())
                || u.ConTent.Contains(input.SearchKey.Trim())
                || u.Appraise.Contains(input.SearchKey.Trim())
            )
            .WhereIF(!string.IsNullOrWhiteSpace(input.MeMo), u => u.MeMo.Contains(input.MeMo.Trim()))
            .WhereIF(input.PredecessorTaskId > 0, u => u.PredecessorTaskId == input.PredecessorTaskId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.PredecessorTaskName), u => u.PredecessorTaskName.Contains(input.PredecessorTaskName.Trim()))
            .WhereIF(!string.IsNullOrWhiteSpace(input.AssignmentName), u => u.AssignmentName.Contains(input.AssignmentName.Trim()))
            .WhereIF(input.ProjectId > 0, u => u.ProjectId == input.ProjectId)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Sno), u => u.Sno.Contains(input.Sno.Trim()))
            .WhereIF(input.BelongtoId != null, u => u.BelongtoId == input.BelongtoId)
            .WhereIF(input.Prioriry != null, u => u.Prioriry == input.Prioriry)
            .WhereIF(input.Instancy != null, u => u.Instancy == input.Instancy)
            .WhereIF(!string.IsNullOrWhiteSpace(input.ConTent), u => u.ConTent.Contains(input.ConTent.Trim()))
            .WhereIF(input.Status != null, u => u.Status == input.Status)
            .WhereIF(input.ProjectedCompletionTime > 0, u => u.ProjectedCompletionTime == input.ProjectedCompletionTime)
            .WhereIF(input.DaysUsed != null, u => u.DaysUsed == input.DaysUsed)
            .WhereIF(!string.IsNullOrWhiteSpace(input.Appraise), u => u.Appraise.Contains(input.Appraise.Trim()))
            .WhereIF(input.EfficiencyLevel != null, u => u.EfficiencyLevel == input.EfficiencyLevel)
            .WhereIF(input.QualityLevel != null, u => u.QualityLevel == input.QualityLevel)
            .WhereIF(input.ReVision != null, u => u.ReVision == input.ReVision)
            .LeftJoin<SysUser>((a, b) => a.BelongtoId == b.Id)
            .LeftJoin<Assignment>((a, b, c) => a.PredecessorTaskId == c.Id)
            .Select((a, b, c) => new AssignmentOutput
            {
                MeMo = a.MeMo,
                ProjectId = a.ProjectId,
                Sno = a.Sno,
                BelongtoId = a.BelongtoId,
                RoleName = b.Account,
                PredecessorTaskId = a.PredecessorTaskId,
                PredecessorTaskName = c.AssignmentName,
                AssignmentName = a.AssignmentName,
                Prioriry = a.Prioriry,
                Instancy = a.Instancy,
                ConTent = a.ConTent,
                DaysUsed = a.DaysUsed,
                Status = a.Status,
                StartTime = a.StartTime,
                ProjectedCompletionTime = a.ProjectedCompletionTime,
                ActyalTime = a.ActyalTime,
                Appraise = a.Appraise,
                CreateTime = a.CreateTime,
                UpdateTime = a.UpdateTime,
                EfficiencyLevel = a.EfficiencyLevel,
                QualityLevel = a.QualityLevel,
                Id = a.Id,
            });
        if (input.StartTimeRange != null && input.StartTimeRange.Count > 0)
        {
            DateTime? start = input.StartTimeRange[0];
            query = query.WhereIF(start.HasValue, u => u.StartTime > start);
            if (input.StartTimeRange.Count > 1 && input.StartTimeRange[1].HasValue)
            {
                var end = input.StartTimeRange[1].Value.AddDays(1);
                query = query.Where(u => u.StartTime < end);
            }
        }
        if (input.ActyalTimeRange != null && input.ActyalTimeRange.Count > 0)
        {
            DateTime? start = input.ActyalTimeRange[0];
            query = query.WhereIF(start.HasValue, u => u.ActyalTime > start);
            if (input.ActyalTimeRange.Count > 1 && input.ActyalTimeRange[1].HasValue)
            {
                var end = input.ActyalTimeRange[1].Value.AddDays(1);
                query = query.Where(u => u.ActyalTime < end);
            }
        }
        return await query.OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);
    }
    /// <summary>
    /// 查询个人任务计划表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet("TaskSchedule")]
    public async Task<List<AssignmentOutput>> TaskSchedule(AssignmentInput input)
    {
        var assignmentDatas = await _rep.AsQueryable()
                                 .Where(u => u.BelongtoId == _userManagerRep.UserId)
                                 .WhereIF(input.ProjectId != 0, u => u.ProjectId == input.ProjectId)
                                 .WhereIF(!string.IsNullOrEmpty(input.Sno), u => u.Sno == input.Sno)
                                 .WhereIF(input.Prioriry != null, u => u.Prioriry == input.Prioriry)
                                 .WhereIF(input.Instancy != null, u => u.Instancy == input.Instancy)
                                 .WhereIF(input.ConTent != null, u => u.ConTent == input.ConTent)
                                 .WhereIF(input.Status != null, u => u.Status == input.Status)
                                 .WhereIF(input.StartTime != null, u => u.StartTime == input.StartTime)
                                 .WhereIF(input.ActyalTime != null, u => u.ActyalTime == input.ActyalTime)
                                 .WhereIF(!string.IsNullOrEmpty(input.Appraise), u => u.Appraise == input.Appraise)
                                 .WhereIF(input.EfficiencyLevel != null, u => u.EfficiencyLevel == input.EfficiencyLevel)
                                 .WhereIF(input.QualityLevel != null, u => u.QualityLevel == input.QualityLevel)
                                 .OrderByDescending(u => u.StartTime)
                                 .Select<AssignmentOutput>()
                                 .ToListAsync();
        return assignmentDatas;
    }
    /// <summary>
    /// 查询个人任务项目
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet("TaskPlanProject")]
    public async Task<SqlSugarPagedList<TaskPlanProjectOutput>> TaskPlanProject(AssignmentInput input)
    {
        var assignmentDatas = await _rep.AsQueryable()
                                  .Where(u => u.BelongtoId == _userManagerRep.UserId)
                                  .InnerJoin<ProjectData>((a, b) => a.ProjectId == b.Id)
                                  .LeftJoin<SysUser>((a, b, c) => a.BelongtoId == c.Id)
                                  .Select((a, b, c) => new TaskPlanProjectOutput
                                  {
                                      ProjectMeMo = b.MeMo,
                                      ProjectSno = b.Sno,
                                      ProjectName = b.Name,
                                      CompanyName = b.CompanyName,
                                      ProjectStatus = b.Status,
                                      ProjectType = b.Type,
                                      ProjectCreatedTime = b.CreateTime,
                                      ProjectUpdatedTime = b.UpdateTime,
                                      Desc = b.Desc,
                                      MeMo = a.MeMo,
                                      Sno = a.Sno,
                                      ProjectId = a.ProjectId,
                                      BelongtoId = a.BelongtoId,
                                      RoleName = c.Account,
                                      PredecessorTaskId = a.PredecessorTaskId,
                                      PredecessorTaskName = a.PredecessorTaskName,
                                      AssignmentName = a.AssignmentName,
                                      Prioriry = a.Prioriry,
                                      Instancy = a.Instancy,
                                      ConTent = a.ConTent,
                                      Status = a.Status,
                                      StartTime = a.StartTime,
                                      ProjectedCompletionTime = a.ProjectedCompletionTime,
                                      ActyalTime = a.ActyalTime,
                                      Id = a.Id,
                                      ReVision = a.ReVision

                                  }).OrderBuilder(input).ToPagedListAsync(input.Page, input.PageSize);


        return assignmentDatas;
    }

    /// <summary>
    /// 增加任务表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Add")]
    public async Task Add(AddAssignmentInput input)
    {
        //判断编码是否唯一
        var isExist = await _rep.AsQueryable().AnyAsync(u => u.Sno == input.Sno && u.IsDelete == false);
        if (isExist)
        {

            throw Oops.Oh("该编码已存在");
        }
        var entity = input.Adapt<Assignment>();
        //判断是否添加前置任务
        if (input.PredecessorTaskId != 0)
        {

            entity.Status = (int)StatusesEnum.Programme;
        }
        else
        {
            entity.Status = (int)StatusesEnum.Commence;
        }
        //生成编码
        var project = await _projectDataRep.AsQueryable().FirstAsync(u => u.Id == input.ProjectId);
        //获取任务数
        var count = await _rep.AsQueryable().CountAsync(u => u.ProjectId == input.ProjectId);
        entity.Sno = project.Name + input.Sno;
        await _rep.InsertAsync(entity);

    }
    /// <summary>
    /// 个人完成任务提交方法
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("FinishButton")]
    [UnitOfWork]//事务开启工作单元
    public async Task FinishButton(UpdateAssignmentInput input)
    {
        var isExist = await _rep.AsQueryable().AnyAsync(u => u.Id == input.Id && u.ReVision == input.ReVision);
        if (!isExist) throw Oops.Oh(ErrorEnum.D1601);
        var assignmentData = input.Adapt<Assignment>();
        assignmentData.Status = (int)StatusesEnum.Successes;
        assignmentData.ActyalTime = DateTime.Now;
        await _rep.AsUpdateable(assignmentData).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();

        //查询是否有任务将本任务设置成前置任务的,如果有更改他的状态为开始
        await _rep.AsUpdateable()
                 .SetColumns(b => b.Status == (int)StatusesEnum.Commence)
                 .Where(u => u.PredecessorTaskId == assignmentData.Id && u.Status == (int)StatusesEnum.Programme)
                 .ExecuteCommandAsync();

    }
    /// <summary>
    /// 删除任务表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Delete")]
    public async Task Delete(DeleteAssignmentInput input)
    {
        var entity = await _rep.GetFirstAsync(u => u.Id == input.Id) ?? throw Oops.Oh(ErrorCodeEnum.D1002);
        await _rep.FakeDeleteAsync(entity);   //假删除
        //await _rep.DeleteAsync(entity);   //真删除
    }

    /// <summary>
    /// 更新任务表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [ApiDescriptionSettings(Name = "Update")]
    public async Task Update(UpdateAssignmentInput input)
    {
        var isExist = await _rep.AsQueryable().AnyAsync(u => u.Id == input.Id && u.ReVision == input.ReVision);
        if (!isExist) throw Oops.Oh(ErrorEnum.D1601);
        var entity = input.Adapt<Assignment>();
        entity.ReVision = input.ReVision + 1;
        await _rep.AsUpdateable(entity).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync();
        if (entity.Status == (int)StatusesEnum.Commence)
        {
            //查询是否有任务将本任务设置成前置任务的,如果有更改他的状态为开始
            await _rep.AsUpdateable()
                  .SetColumns(b => b.Status == (int)StatusesEnum.Programme)
                  .Where(u => u.PredecessorTaskId == entity.Id && u.Status == (int)StatusesEnum.Programme)
                  .ExecuteCommandAsync();
        }
    }
    /// <summary>
    /// 获取根据任务任务id获取任务详情和项目信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("GetTaskDetails")]
    public async Task<TaskPlanProjectOutput> GetTaskDetails(QueryeassignmentDataInput input)
    {
        //判断编码是否唯一
        var isExist = await _rep.AsQueryable().AnyAsync(u => u.Id == input.Id);
        if (!isExist)
        {

            throw Oops.Oh("不存在该任务");
        }
        var assignmentDatas = await _rep.AsQueryable()
                                  .Where(u => u.BelongtoId == _userManagerRep.UserId)
                                  .Where(u => u.Id == input.Id)
                                  .InnerJoin<ProjectData>((a, b) => a.ProjectId == b.Id)
                                  .LeftJoin<SysUser>((a, b, c) => a.BelongtoId == c.Id)
                                   .Select((a, b, c) => new TaskPlanProjectOutput
                                   {
                                       ProjectMeMo = b.MeMo,
                                       ProjectSno = b.Sno,
                                       ProjectName = b.Name,
                                       CompanyName = b.CompanyName,
                                       ProjectStatus = b.Status,
                                       ProjectType = b.Type,
                                       ProjectCreatedTime = b.CreateTime,
                                       ProjectUpdatedTime = b.UpdateTime,
                                       Desc = b.Desc,
                                       MeMo = a.MeMo,
                                       Sno = a.Sno,
                                       ProjectId = a.ProjectId,
                                       BelongtoId = a.BelongtoId,
                                       RoleName = c.RealName,
                                       PredecessorTaskId = a.PredecessorTaskId,
                                       PredecessorTaskName = a.PredecessorTaskName,
                                       AssignmentName = a.AssignmentName,
                                       Prioriry = a.Prioriry,
                                       Instancy = a.Instancy,
                                       ConTent = a.ConTent,
                                       Status = a.Status,
                                       StartTime = a.StartTime,
                                       ProjectedCompletionTime = a.ProjectedCompletionTime,
                                       ActyalTime = a.ActyalTime,

                                   }).OrderByDescending(u => u.StartTime).ToListAsync();



        return assignmentDatas[0];
    }
    /// <summary>
    /// 获取任务表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "Detail")]
    public async Task<Assignment> Detail([FromQuery] QueryByIdAssignmentInput input)
    {
        return await _rep.GetFirstAsync(u => u.Id == input.Id);
    }

    /// <summary>
    /// 获取任务表列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [ApiDescriptionSettings(Name = "List")]
    public async Task<List<AssignmentOutput>> List([FromQuery] AssignmentInput input)
    {
        return await _rep.AsQueryable().Select<AssignmentOutput>().ToListAsync();
    }


    /// <summary>
    /// 上传单片机程序
    /// </summary>
    /// <param name="httpContextAccessor"></param>
    /// <returns></returns>
    [HttpPost("SinglechipAdd")]
    [UnitOfWork]//事务开启工作单元
    public async Task SinglechipAdd([FromServices] IHttpContextAccessor httpContextAccessor)
    {
        Random r = new Random();
        var files = httpContextAccessor.HttpContext.Request.Form.Files["ProgramCodeUrl"];
        var files2 = httpContextAccessor.HttpContext.Request.Form.Files["EEPROMUrl"];
        var files3 = httpContextAccessor.HttpContext.Request.Form.Files["BurningInstructionsUrl"];
        //获取表单数据，因为传文件不能传数据
        SinglechipInput datas = _jsonSerializerRep.Deserialize<SinglechipInput>(App.HttpContext.Request.Form["inputs"]);
        UploadSinglechip models = datas.Adapt<UploadSinglechip>();
        //生成编码
        var project = await _projectDataRep.AsQueryable().FirstAsync(u => u.Id == datas.ProjectId);
        //获取任务数
        var count = await _rep.AsQueryable().CountAsync(u => u.ProjectId == datas.ProjectId);
        models.Sno = project.Sno + r.Next(10, 99) + count;
        models.DefectRate = models.DefectRate / 1000;
        if (files != null)
        {
            FileInput2 model = new FileInput2();
            model.DbId = models.Id + r.Next(10, 99);
            model.Module = datas.Module;
            var data = await _fileServiceRep.UniversalUpload(files, model);

            models.ProgramCodeUrl = data.Url;

        }
        if (files2 != null)
        {
            FileInput2 model = new FileInput2();
            model.DbId = models.Id + +r.Next(10, 99);
            model.Module = datas.Module;
            var data = await _fileServiceRep.UniversalUpload(files, model);

            models.EEPROMUrl = data.Url;
        }
        if (files3 != null)
        {

            FileInput2 model = new FileInput2();
            model.DbId = models.Id + +r.Next(10, 99);
            model.Module = datas.Module;
            var data = await _fileServiceRep.UniversalUpload(files, model);

            models.BurningInstructionsUrl = data.Url;
        }

        await _uploadSinglechipRep.InsertAsync(models);
        var goods = await _goodsInformationRep.AsQueryable().FirstAsync(u => u.Id == datas.BurnFinishedProductsModel);
        //新建bom
        var isExist = await _bomMasterRep.AsQueryable().AnyAsync(u => u.PartNo == goods.Sno );
        if (isExist) throw Oops.Oh("该烧录成品型号已存在Bom");
        var bomMarster_Data = datas.Adapt<BomMaster>();
        bomMarster_Data.Cycle = 1;
        bomMarster_Data.PartNo = goods.Sno;
        bomMarster_Data.Status = "审核完成！";
        bomMarster_Data.CompleteStatus = (Int32)ReviewStatusEnum.Approved;
        bomMarster_Data.RestrictedLots = 100;//默认100
        bomMarster_Data.Statuses = (int)BOMLimitTypeEnum.LimitedApproval; 
        await _bomMasterRep.InsertAsync(bomMarster_Data);
        var goods2 = await _goodsInformationRep.AsQueryable().FirstAsync(u => u.Id == datas.MCUModel);
        //新建子料
        if (goods.Sno == goods2.Sno)
        {
            throw Oops.Oh("父级物料与子集物料冲突请核对");
        }

        //添加子-正式
        var BomDetails = datas.Adapt<BomDetails>();
        BomDetails.BomId = bomMarster_Data.Id;
        BomDetails.ParentPartId = bomMarster_Data.Id;
        BomDetails.ParentPartNo = goods.Sno;
        BomDetails.Locator = "";
        BomDetails.PartNo = goods2.Sno;
        BomDetails.DefectRate = BomDetails.DefectRate / 1000;

        BomDetails.NoPur = true;
        BomDetails.CompleteStatus = (int)ReviewStatusEnum.Approved;
        await _bomDetailsRep.InsertAsync(BomDetails);
        //添加子-待审核
        var BomDetailsCopy = BomDetails.Adapt<BomDetailsCopy>();
        await _bomDetailsCopyRep.InsertAsync(BomDetailsCopy);

    }
    /// <summary>
    /// 上传Layout
    /// </summary>
    /// <param name="httpContextAccessor"></param>
    /// <returns></returns>
    [HttpPost("LayoutAdd")]
    public async Task LayoutAdd([FromServices] IHttpContextAccessor httpContextAccessor)
    {
        var files = httpContextAccessor.HttpContext.Request.Form.Files["PCBUrl"];
        var files2 = httpContextAccessor.HttpContext.Request.Form.Files["SchematicDiagramImageUrl"];
        var files3 = httpContextAccessor.HttpContext.Request.Form.Files["SMTImageUrl"];
        var files4 = httpContextAccessor.HttpContext.Request.Form.Files["GerberUrl"];
        Random r = new Random();
        //获取表单数据，因为传文件不能传数据
        LayoutInput datas = _jsonSerializerRep.Deserialize<LayoutInput>(App.HttpContext.Request.Form["inputs"]);
        Layout models = datas.Adapt<Layout>();
        if (files != null)
        {
            FileInput2 model = new FileInput2();
            model.DbId = models.Id + r.Next(10, 99);
            model.Module = datas.Module;
            var data = await _fileServiceRep.UniversalUpload(files, model);

            models.PCBUrl = data.Url;

        }
        if (files2 != null)
        {
            FileInput2 model = new FileInput2();
            model.DbId = models.Id + r.Next(10, 99);
            model.Module = datas.Module;
            var data = await _fileServiceRep.UniversalUpload(files, model);
            models.SchematicDiagramImageUrl = data.Url;
        }
        if (files3 != null)
        {

            FileInput2 model = new FileInput2();
            model.DbId = models.Id + r.Next(10, 99);
            model.Module = datas.Module;
            var data = await _fileServiceRep.UniversalUpload(files, model);

            models.SMTImageUrl = data.Url;
        }
        if (files4 != null)
        {


            FileInput2 model = new FileInput2();
            model.DbId = models.Id + r.Next(10, 99);
            model.Module = datas.Module;
            var data = await _fileServiceRep.UniversalUpload(files, model);
            models.GerberUrl = data.Url;

        }
        //生成编码
        var project = await _projectDataRep.AsQueryable().FirstAsync(u => u.Id == datas.ProjectId);
        //获取任务数
        var count = await _rep.AsQueryable().CountAsync(u => u.ProjectId == datas.ProjectId);
        models.Sno = project.Sno + r.Next(10, 99) + count;
        await _layoutRep.InsertAsync(models);
    }

    /// <summary>
    /// 上传上位机程序
    /// </summary>
    /// <param name="httpContextAccessor"></param>
    /// <returns></returns>
    [HttpPost("UpperComputerAdd")]
    public async Task UpperComputerAdd([FromServices] IHttpContextAccessor httpContextAccessor)
    {
        Random r = new Random();
        var files = httpContextAccessor.HttpContext.Request.Form.Files["ProgramCodeUrl"];

        //获取表单数据，因为传文件不能传数据
        UpperComputerInput datas = _jsonSerializerRep.Deserialize<UpperComputerInput>(App.HttpContext.Request.Form["inputs"]);
        UpperComputerProgram models = datas.Adapt<UpperComputerProgram>();
        if (files != null)
        {
            FileInput2 model = new FileInput2();
            model.DbId = models.Id + r.Next(10, 99);
            model.Module = datas.Module;
            var data = await _fileServiceRep.UniversalUpload(files, model);

            models.ProgramCodeUrl = data.Url;

        }
        //生成编码
        var project = await _projectDataRep.AsQueryable().FirstAsync(u => u.Id == datas.ProjectId);
        //获取任务数
        var count = await _rep.AsQueryable().CountAsync(u => u.ProjectId == datas.ProjectId);
        models.Sno = project.Sno + r.Next(10, 99) + count;

        await _upperComputerProgramRep.InsertAsync(models);
    }


}

