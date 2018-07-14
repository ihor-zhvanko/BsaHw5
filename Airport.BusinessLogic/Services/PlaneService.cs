using System;
using System.Linq;
using System.Collections.Generic;
using Airport.BusinessLogic.Models;

using Airport.Data.Models;
using Airport.Data.UnitOfWork;

using AutoMapper;

namespace Airport.BusinessLogic.Services
{
  public interface IPlaneService : IService<PlaneModel>
  {
    IList<PlaneDetails> GetAllDetails();
    PlaneDetails GetDetails(int id);
  }

  public class PlaneService : BaseService<PlaneModel, Plane>, IPlaneService
  {
    IPlaneTypeService _planeTypeService;
    public PlaneService(
      IUnitOfWork unitOfWork,
      IPlaneTypeService planeTypeService
      )
      : base(unitOfWork)
    {
      _planeTypeService = planeTypeService;
    }

    public IList<PlaneDetails> GetAllDetails()
    {
      var planes = GetAll();
      var planeTypes = _planeTypeService.GetAll();

      var joined = from plane in planes
                   join planeType in planeTypes on plane.PlaneTypeId equals planeType.Id
                   select PlaneDetails.Create(plane, planeType);

      return joined.ToList(); ;
    }

    public PlaneDetails GetDetails(int id)
    {
      var plane = GetById(id);
      var planeType = _planeTypeService.GetById(plane.PlaneTypeId);

      return PlaneDetails.Create(plane, planeType);
    }
  }
}