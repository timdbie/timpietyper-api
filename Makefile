migration:
	dotnet ef migrations add $(NAME) -p TimpieTyper.Persistence -s TimpieTyper.Api
update:
	dotnet ef database update -p TimpieTyper.Persistence -s TimpieTyper.Web