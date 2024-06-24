using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPIExamenEP.DTOs;
using WebAPIExamenEP.Services;

namespace WebAPIExamenEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;

        }
        // Método para generar un token JWT.
        [HttpPost("GenerateToken")]
        public IActionResult GenerateToken([FromBody] string userId)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("DTemp#123@zqxwcecoban2024++123456789"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "your_issuer",
                audience: "your_audience",
                claims: new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId)
                },
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
        //Cambiar PIN
        [Authorize]
        [HttpPost("ChangePIN")]  
        public async Task<IActionResult> ChangePIN([FromBody] ChangePinDto dto)
        {
            var result = await _service.ChangePINAsync(dto);
            if (result == "Número de tarjeta o PIN no válido")
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        //Consultar saldo
        [Authorize]
        [HttpGet("CheckBalance")]
        public async Task<IActionResult> CheckBalance(string cardNumber, string pin)
        {
            var balance = await _service.CheckBalanceAsync(cardNumber, pin);
            if (balance == null)
            {
                return BadRequest("Número de tarjeta o PIN no válido");
            }
            return Ok(balance);
        }
        //Depósito
        [Authorize]
        [HttpPost("Deposit")]      
        public async Task<IActionResult> Deposit([FromBody] DepositDto dto)
        {
            // Llama al servicio para depositar dinero de manera asíncrona.
            var result = await _service.DepositAmountAsync(dto);
            return Ok(result);
        }
        //Retiro
        [Authorize]
        [HttpPost("Withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawDto dto)
        {
            // Llama al servicio para retirar dinero de manera asíncrona.
            var result = await _service.WithdrawAmountAsync(dto);
            if (result == "Número de tarjeta o PIN no válido" || result == "Fondos insuficientes")
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
