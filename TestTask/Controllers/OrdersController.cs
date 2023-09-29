using Microsoft.AspNetCore.Mvc;
using TestTask.Services.Interfaces;

namespace TestTask.Controllers
{
    /// <summary>
    /// Orders controller.
    /// DO NOT change anything here. Use created contract and provide only needed implementation.
    /// </summary>
    [Route("api/v1/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        /// <summary>
        /// Returns selected order. 
        /// Selection rules are specified in Task description provided by recruiter
        /// </summary>
        [HttpGet]
        [Route("selected-order")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this.orderService.GetOrder();
                return result == null ? 
                    this.NoContent() : 
                    this.Ok(result);
            }
            catch(Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Returns list of selected orders. 
        /// Selection rules are specified in Task description provided by recruiter
        /// </summary>
        [HttpGet]
        [Route("selected-orders")]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var result = await this.orderService.GetOrders();
                return this.Ok(result);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}
