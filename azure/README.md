# Azure implementation of the serverless Parking Garage Application

## Running locally

### Prerequisites

- Visual Studio 2017 (or higher)
    - Azure Workload
    - Azure Functions and Webjobs Extension 
OR

- Visual Studio Code
    - Azure Functions Extension

### Visual Studio

- Open the `ServerlessParking.sln`
- Restore & Build the solution.
- Run the ServerlessParking.Application project.
    - The local development runtime should start.
- Use Postman or VS Code with REST Client to trigger the `ParkingGarageCarEntryOrchestration` orchestration function.

## Deployment to Azure

### Prerequisites

- You require an Azure account
- You need to install the [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest).

### Create a Function App using Powershell

- Open Powershell
- Run `az login` and follow the instructions
- Set the following variables and replace values between `<` and `>` with your own:
    - `$resourceGroupName="<RESOURCE_GROUP_NAME>"`
    - `$storageAccountName="<STORAGE_ACCOUNT_NAME>"` (limited to 24 alphanumeric characters)
    - `$functionAppName="<FUNCTION_APP_NAME>"`
    - `$locationName="<LOCATION_NAME>"` (this should be one of the Azure regions e.g. `westeurope`).
- Run `az group create --name $resourceGroupName --location $locationName`
- Run `az storage account create --name $storageAccountName --location $locationName --resource-group $resourceGroupName --sku Standard_LRS`
- Run ` az functionapp create --name $functionAppName --storage-account $storageAccountName --consumption-plan-location $locationName --resource-group $resourceGroupName`

More info: https://docs.microsoft.com/en-us/azure/azure-functions/scripts/functions-cli-create-serverless 

### Adding Application Insights to the Function App

https://docs.microsoft.com/en-us/azure/azure-monitor/app/create-new-resource

`az functionapp config appsettings set --name $functionAppName --resource-group $resourceGroupName --settings 'APPINSIGHTS_INSTRUMENTATIONKEY = <Instrumentation Key>'`

