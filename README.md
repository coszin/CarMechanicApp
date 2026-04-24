# Examination - CarMechanic Application

**Elev:** Oscar Svahn
**Datum:** 2026-04-16
**Domän:** CarMechanic

## Instruktioner

Du har fått en Console-applikation i **Onion Architecture** som innehåller buggar och
saknade metodimplementationer. Din uppgift är att:

1. **Felsöka och fixa 8 buggar** i Application- och Infrastructure-lagren
2. **Implementera 4 saknade metoder** (markerade med `NotImplementedException`)

## Regler

- Du får **INTE** ändra namn på klasser, metoder, namespaces eller interfaces
- Du får **INTE** lägga till nya projekt eller ändra projektstrukturen
- Du får **INTE** ändra i testprojektet
- Alla metodsignaturer måste vara exakt som de är (parametrar, returtyper)
- Följ Onion Architecture-principerna (beroenden pekar inåt)

## Projektstruktur

```
CarMechanicApp/
├── CarMechanic.Domain/       # Entiteter, enums, interfaces (ÄNDRA INTE)
├── CarMechanic.Application/  # Services - HÄR FIXAR DU BUGGAR & IMPLEMENTERAR METODER
├── CarMechanic.Infrastructure/ # Repositories & factories - KAN INNEHÅLLA BUGGAR
└── CarMechanic.Console/      # Consoleappen (valfritt att ändra för felsökning)

CarMechanicApp.Tests/          # Testprojektet - ÄNDRA INTE
```

## Att fixa: Buggar

1. **Bugg i `GetAverageInvoiceAmount`** - GetAverageInvoiceAmount uses Sum instead of Average
2. **Bugg i `ReassignMechanic`** - ReassignMechanic uses AND instead of OR in status check so it never prevents reassignment
3. **Bugg i `GetUnpaid`** [Infrastructure] - InvoiceRepository GetUnpaid returns paid invoices instead of unpaid
4. **Bugg i `GetByDateRange`** [Infrastructure] - InvoiceRepository GetByDateRange excludes boundary dates
5. **Bugg i `CreateWorkOrder`** [Infrastructure] - WorkOrderFactory sets initial status to Completed instead of Pending
6. **Bugg i `RestockPart`** - RestockPart subtracts instead of adding to stock
7. **Bugg i `GetPartUsageReport`** - GetPartUsageReport subtracts part quantity instead of adding when the part already exists in the report
8. **Bugg i `ReassignMechanic`** - ReassignMechanic does not persist the mechanic change (Update call removed)

## Att implementera: Saknade metoder

1. **`AddPartToWorkOrder`** - Implement AddPartToWorkOrder that adds a part line to a work order
2. **`GetMechanicRevenue`** - Implement GetMechanicRevenue that calculates total revenue from completed work orders
3. **`ReassignMechanic`** - Implement ReassignMechanic that validates the work order is not completed/cancelled, then changes its assigned mechanic
4. **`GetVehiclesDueForService`** - Implement GetVehiclesDueForService that returns vehicles at or above a mileage threshold

## Verifiering

När du är klar, kör testerna:

```bash
dotnet test CarMechanicApp.Tests/CarMechanic.Tests.csproj
```

**Alla tester gröna = Godkänd uppgift!**
