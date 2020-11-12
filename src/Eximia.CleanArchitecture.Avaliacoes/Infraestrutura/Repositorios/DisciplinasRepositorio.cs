﻿using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Eximia.CleanArchitecture.Avaliacoes.Dominio.Disciplinas;
using Eximia.CleanArchitecture.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Eximia.CleanArchitecture.Avaliacoes.Infraestrutura.Repositorios
{
    public sealed class DisciplinasRepositorio : IDisciplinasRepositorio
    {
        private readonly AvaliacoesDbContext _context;

        public DisciplinasRepositorio(AvaliacoesDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Maybe<Disciplina>> RecuperarAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Disciplinas.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }
    }
}