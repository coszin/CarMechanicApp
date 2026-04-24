using CarMechanic.Domain.Entities;
using CarMechanic.Domain.Enums;

namespace CarMechanic.Domain.Interfaces;

public interface IWorkOrderRepository
{
    WorkOrder? GetById(int id);
    List<WorkOrder> GetAll();
    List<WorkOrder> GetByVehicleId(int vehicleId);
    List<WorkOrder> GetByMechanicId(int mechanicId);
    List<WorkOrder> GetByStatus(WorkOrderStatus status);
    void Add(WorkOrder workOrder);
    void Update(WorkOrder workOrder);
    void PartToWorkdOrder(int workOrderId, int partId, int quantity, decimal unitPrice);
    void ReassignMechanicById(int workOrderId, int newMechanicId);
}
