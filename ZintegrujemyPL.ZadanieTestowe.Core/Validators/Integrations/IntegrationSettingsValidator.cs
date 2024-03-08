using System;
using ZintegrujemyPL.ZadanieTestowe.Core.Interfaces.Validators.Integrations;
using ZintegrujemyPL.ZadanieTestowe.Core.Settings;

namespace ZintegrujemyPL.ZadanieTestowe.Core.Validators.Integrations
{
    public class IntegrationSettingsValidator : IIntegrationSettingsValidator
    {
        private readonly IIntegrationDescValidator _integrationDescValidator;
        public IntegrationSettingsValidator(IIntegrationDescValidator integrationDescValidator)
        {
            _integrationDescValidator = integrationDescValidator;
        }

        public void Validate(IntegrationSettings integrationSettings, string name = "")
        {
            try
            {
                if (integrationSettings == null)
                {
                    throw new ArgumentNullException(nameof(integrationSettings), "IntegrationSettings nie może być null.");
                }

                if (string.IsNullOrWhiteSpace(integrationSettings.ShippingTime))
                {
                    throw new ArgumentException("ShippingTime nie może być puste.", nameof(integrationSettings.ShippingTime));
                }

                _integrationDescValidator.Validate(integrationSettings.Products, "Products");
                _integrationDescValidator.Validate(integrationSettings.Inventory, "Inventory");
                _integrationDescValidator.Validate(integrationSettings.Prices, "Prices");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("AppSettings.IntegrationSettings." + ex.Message);
            }
        }
    }

}
