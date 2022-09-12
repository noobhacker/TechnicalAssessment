# TechnicalAssessment

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