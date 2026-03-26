mkdir Controllers,Models,DTOs,Data,Repositories,Services,Exceptions,Helpers,Mappings

ni Controllers/AccountController.cs
ni Models/Account.cs
ni DTOs/CreateAccountDto.cs
ni DTOs/AccountDto.cs
ni DTOs/TransactionDto.cs
ni Data/AppDbContext.cs
ni Repositories/IAccountRepository.cs
ni Repositories/AccountRepository.cs
ni Services/IAccountService.cs
ni Services/AccountService.cs
ni Exceptions/NotFoundException.cs
ni Exceptions/BadRequestException.cs
ni Exceptions/GlobalExceptionMiddleware.cs
ni Helpers/AccountNumberGenerator.cs
ni Mappings/MappingProfile.cs