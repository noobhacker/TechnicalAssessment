# TechnicalAssessment

This project is designed with testability in mind.

High level architecture design
| Presentation | Handles routing, Swagger, endpoints. Serves as a catalog for Apis. Also catches exception propogation to return appropriate http status code. |
| Core | Handles core logic, validation and data contracts.All other layers depends on Core. Designed with fully isolated testability in mind. |
| Infrastructure | External implementations based on what Core needs. |

isolate command and dto so core layer no need to know about its pass from header or body (least knowledge)

ensure badrequest if input is null (better explict)

why cqrs: small, good folder management and based on my experience this kind of api can go big in very short time
additional bi-product: can make use of extra read sql cluster for scalability

assume all input are nullable, but output are not nullable

simple and testability in mind, if abstraction helps in simplify testing, do it

violates some principle like directly return http code from Core layer
Actually no, exception are in core and infra depends on core.

Dependency Inversion by putting core logic into .Core.

do not mix dto and database orm entities. Always think can reuse but shoot myself in the foot.

enabled is in database so later on can add other flags

as long as decoupling techniques are introduce to make code more testable, it is not having too much abstraction layers.

Presentation = swaggers, routings, maybe authentications. 
Core = isolated from infrastructure like rest server and database.
Infrastructure = Data access. Repository are created based on mocks needed (more test driven).

NotModified when cant find email/feature, if connection issues goes to internal server error, if value is same then update anyway

This may not be what I will do if I was asked to deliver this simple feature, but
Based on my experience on how codebase expands and designed to expand with ease for the next 3-6 months.

Excluded all async feature for clearer demo purpose.


Database: Presistance Add Migration
Presentation Update-Database (due to database credential is here)
