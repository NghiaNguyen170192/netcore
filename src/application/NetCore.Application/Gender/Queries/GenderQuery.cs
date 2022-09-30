﻿using MediatR;
using NetCore.Application.Queries.Dtos;

namespace NetCore.Application.Queries;

public record GenderQuery(Guid Id) : IRequest<GenderQueryDto>;
