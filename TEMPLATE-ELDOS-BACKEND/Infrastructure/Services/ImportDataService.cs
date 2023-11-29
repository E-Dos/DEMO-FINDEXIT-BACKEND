using TEMPLATE_ELDOS_BACKEND.Domain.Interfaces;

public class ImportDataService : IImportDataService
{
    //private readonly ILogger<ImportDataService> logger;
    //private readonly AppDbContext _db;
    //private readonly NotificationHub _hubContext;

    //public ImportDataService(ILogger<ImportDataService> appLogger, AppDbContext appDb, NotificationHub hubContext)
    //{
    //    logger = appLogger;
    //    _db = appDb;
    //    _hubContext = hubContext;
    //}
    //public async Task ParsingData(IFormFile files)
    //{
    //    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    //    string PLBDATAPath = Path.Combine(desktopPath, "DeviceData");

    //    try
    //    {
    //        if (files.Length > 0)
    //        {
    //            string filePath = Path.Combine(PLBDATAPath, files.FileName);

    //            using (var stream = new FileStream(filePath, FileMode.Open))
    //            {
    //                using (var reader = new StreamReader(stream))
    //                {
    //                    var jsonData = await reader.ReadToEndAsync();
    //                    var jsonArray = JArray.Parse(jsonData);

    //                    var dataItem = jsonArray[0].ToObject<DataItem>();
    //                    var subItems = jsonArray[1].ToObject<List<SubItem>>();

    //                    await SaveDataToDBAsync(dataItem, subItems);
    //                }
    //            }
    //        }
    //        logger.LogInformation("Данные загружены");
    //    }
    //    catch (Exception ex)
    //    {
    //        logger.LogError(ex.Message);
    //    }
    //}

    //private async Task SaveDataToDBAsync(DataItem item, List<SubItem> subItems)
    //{
    //    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
    //    optionsBuilder.UseSqlServer("Server=DOSIK\\SQLEXPRESS;Database=SCPB_BARS;Trusted_Connection=True;TrustServerCertificate=True;");

    //    var deviceModel = new Device();
    //    var dbContext = new AppDbContext(optionsBuilder.Options);
    //    var valueDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(item.timestamp).ToLocalTime();
    //    double maxValue = 0;
    //    var ownerId = _db.Devices.FirstOrDefault(d => d.Id == long.Parse(item.imei)).OwnerId;
    //    var connectionIds = _db.Users.Where(u=> u.OwnerId == ownerId);
    //    try
    //    {
    //        var existDevice = dbContext.Devices.FirstOrDefault(x => x.Id == long.Parse(item.imei));

    //        if (existDevice is null)
    //        {
    //            deviceModel.Id = long.Parse(item.imei);
    //            deviceModel.Created = DateTime.Now;
    //            deviceModel.FWVersion = 10;
    //            deviceModel.OwnerId = 999;
    //            deviceModel.Description = "150ДЭЛ";
    //            deviceModel.Model = "ДЭЛ";

    //            dbContext.Devices.Add(deviceModel);
    //            await dbContext.SaveChangesAsync();
    //        }

    //        int existMeasureId = 0;
    //        var IsExistMeasure = dbContext.Measures.FirstOrDefault(x => x.DeviceId == long.Parse(item.imei)
    //                                                                      && x.WELLID == item.skv
    //                                                                      && x.PadId == item.kust
    //                                                                      && x.FieldId == item.mr
    //                                                                      && x.BrigadeNum == item.br);

    //        if (IsExistMeasure == null)
    //        {
    //            var measure = new Measure
    //            {
    //                OnDateTime = valueDate,
    //                DeviceId = long.Parse(item.imei),
    //                WELLID = item.skv,
    //                PadId = item.kust,
    //                FieldId = item.mr,
    //                BrigadeNum = item.br,
    //                ShopId = item.ceh,
    //                SPUID = item.spy,
    //                FKMAX = double.Parse(item.fkmax)

    //            };
    //            maxValue = measure.FKMAX ?? 0;
    //            dbContext.Measures.Add(measure);
    //            await dbContext.SaveChangesAsync();
    //            existMeasureId = measure.Id;
    //        }
    //        else
    //        {
    //            existMeasureId = IsExistMeasure.Id;
    //        }

    //        if (subItems != null && subItems.Any())
    //        {
    //            foreach (var points in subItems)
    //            {
    //                var subItemEntity = new Points
    //                {
    //                    DeviceId = long.Parse(item.imei),
    //                    MeasureId = existMeasureId,
    //                    PID = int.Parse(points.id),
    //                    Num = double.Parse(points.num),
    //                    OnDateTime = valueDate,
    //                };
    //                dbContext.Points.Add(subItemEntity);
    //                if (double.Parse(points.num) >= maxValue)
    //                {
    //                    bool msgExist = _db.Messages.Any(m => m.DeviceId == subItemEntity.Id
    //                    && m.PointId == subItemEntity.Id && m.OnDateTime == valueDate
    //                    && m.MsgLevel == (int)MessageLevelEnum.DeviceMaxValWarning);
    //                    var pointType = _db.PointTypes.FirstOrDefault(p => p.Id == int.Parse(points.id));
    //                    if (!msgExist)
    //                    {
    //                        string msgTxt = $"Прибор {subItemEntity.Id}, {pointType.Name} превысил макс. зн. в {valueDate}";
    //                        var msgModel = new Messages
    //                        {
    //                            MsgLevel = (int)MessageLevelEnum.DeviceMaxValWarning,
    //                            DeviceId = subItemEntity.Id,
    //                            OnDateTime = valueDate,
    //                            PointId = subItemEntity.Id,
    //                            MsgText = msgTxt
    //                        };
    //                        _db.Messages.Add(msgModel);
    //                        await _db.SaveChangesAsync();
    //                        foreach (var connId in connectionIds)
    //                        {
    //                            await _hubContext.Clients.Client(connId.ConnectionIdHub).SendAsync("Send", msgTxt);
    //                        }
    //                    }
    //                }
    //            }
    //            await dbContext.SaveChangesAsync();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        logger.LogError(ex, "Ошибка при сохранении данных в базу данных.");
    //        throw;
    //    }
    //    finally
    //    {
    //        dbContext.Dispose();
    //    }
    //}
    public Task ParsingData(IFormFile files)
    {
        throw new NotImplementedException();
    }
}
