using FluentValidation;

namespace ResTIConnect.Application.UseCases.GetAllUser;

public class GetAllUserValidator : AbstractValidator<GetAllUserRequest>
{
    public GetAllUserValidator()
    {
        //Sem validação
    }

}
