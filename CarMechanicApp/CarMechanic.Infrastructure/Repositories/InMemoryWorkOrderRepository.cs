using CarMechanic.Domain.Entities;
using CarMechanic.Domain.Enums;
using CarMechanic.Domain.Interfaces;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace CarMechanic.Infrastructure.Repositories;

public class InMemoryWorkOrderRepository : IWorkOrderRepository
{
    private readonly List<WorkOrder> _workOrders = new();
    private readonly List<WorkOrderPart> _orderParts = new();

    public WorkOrder? GetById(int id) => _workOrders.FirstOrDefault(wo => wo.Id == id);
    public List<WorkOrder> GetAll() => _workOrders;
    public List<WorkOrder> GetByVehicleId(int vehicleId) => _workOrders.Where(wo => wo.VehicleId == vehicleId).ToList();
    public List<WorkOrder> GetByMechanicId(int mechanicId) => _workOrders.Where(wo => wo.MechanicId == mechanicId).ToList();
    // BUG_TARGET: GetByStatus
    public List<WorkOrder> GetByStatus(WorkOrderStatus status) => _workOrders.Where(wo => wo.Status == status).ToList();
    public void Add(WorkOrder workOrder) => _workOrders.Add(workOrder);

    public void Update(WorkOrder workOrder)
    {
        var index = _workOrders.FindIndex(wo => wo.Id == workOrder.Id);
        if (index >= 0)
            _workOrders[index] = workOrder;
    }

    public void PartToWorkdOrder(int workOrderId, int partId, int quantity, decimal unitPrice)
    {
        if (quantity <= 0) throw new ArgumentException("Quantity most be more then 0");
        else
        {
            var order = GetById(workOrderId);
            order!.Parts.Add(
            new WorkOrderPart
            {
                Id = 20,
                WorkOrderId = workOrderId,
                PartId = partId,
                Quantity = quantity,
                UnitPrice = unitPrice,
            });
        }
    }

    public void ReassignMechanicById(int workOrderId, int newMechanicId)
    {
        //var mechanic = _mechanicRepository.GetMechanicById(newMechanicId);
        //if (mechanic == null) throw new InvalidOperationException();
        //var order = GetById(workOrderId);
        //if (order.Status != WorkOrderStatus.Pending || order.Status != WorkOrderStatus.InProgress) throw new InvalidOperationException();
        //order.MechanicId = newMechanicId;
    }
}