using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Api.RoutingConventions;

public class RoutePrefixConvention(AttributeRouteModel centralPrefix) : IApplicationModelConvention
{
    public void Apply(ApplicationModel application)
    {
        foreach (var controller in application.Controllers)
        {
            var matchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList();
            if (matchedSelectors.Count != 0)
            {
                foreach (var selectorModel in matchedSelectors)
                {
                    selectorModel.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(centralPrefix, selectorModel.AttributeRouteModel);
                }
            }
            else
            {
                foreach (var selectorModel in controller.Selectors)
                {
                    selectorModel.AttributeRouteModel = centralPrefix;
                }
            }
        }
    }
}