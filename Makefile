prod:
	docker compose up --build -d prod
dev:
	docker compose -f docker-compose.dev.yml up --build -d dev
test:
	docker compose -f docker-compose.dev.yml run --rm test
clean:
	docker compose down --volumes --remove-orphans && \
	docker rmi -f timpietyper-api timpietyper-api-test || true
migration:
	dotnet ef migrations add $(NAME) -p TimpieTyper.Persistence -s TimpieTyper.Api
update:
	dotnet ef database update -p TimpieTyper.Persistence -s TimpieTyper.Web