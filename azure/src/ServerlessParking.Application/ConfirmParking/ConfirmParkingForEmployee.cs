﻿using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using ServerlessParking.Application._DependencyInjection;
using ServerlessParking.Services.ParkingConfirmation;
using ServerlessParking.Services.ParkingConfirmation.Models;

namespace ServerlessParking.Application.ConfirmParking
{
    public static class ConfirmParkingForEmployee
    {
        [FunctionName(nameof(ConfirmParkingForEmployee))]
        public static async Task<ConfirmParkingResponse> Run(
            [ActivityTrigger] ConfirmParkingRequest request,
            [Inject] IParkingConfirmationService parkingConfirmationService,
            ILogger logger)
        {
            logger.LogInformation($"Started {nameof(ConfirmParkingForEmployee)} for licensePlate {request.LicensePlateRegistration.Number}.");

            var response = await parkingConfirmationService.ConfirmParkingAsync(request, false);

            return response;
        }
    }
}
