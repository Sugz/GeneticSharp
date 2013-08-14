using System;
using System.Collections.Generic;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Randomizations;
using NUnit.Framework;
using Rhino.Mocks;
using TestSharp;
using HelperSharp;

namespace GeneticSharp.Domain.UnitTests.Mutations
{
    [TestFixture]
    public class TworsMutationTest
    {
        [TearDown]
        public void Cleanup()
        {
            RandomizationProvider.Current = new BasicRandomization();
        }

        [Test()]
        public void Mutate_LessThanTwoGenes_Exception()
        {
            var target = new TworsMutation();
            var chromosome = MockRepository.GenerateStub<ChromosomeBase>(1);
			chromosome.ReplaceGenes(0, new Gene[] 
			{ 
				new Gene() { Value = 1 },				
			});

            ExceptionAssert.IsThrowing(new MutationException(target, "A chromosome should have, at least, 2 genes. {0} has only 1 gene.".With(chromosome.GetType().Name)), () =>
            {
                target.Mutate(chromosome, 0);
            });
        }

        [Test()]
        public void Mutate_NoProbality_NoExchangeGenes()
        {
            var target = new TworsMutation();
            var chromosome = MockRepository.GenerateStub<ChromosomeBase>(4);
			chromosome.ReplaceGenes(0, new Gene[] 
            { 
				new Gene() { Value = 1 },
				new Gene() { Value = 2 },
				new Gene() { Value = 3 }, 
                new Gene() { Value = 4 },
			});

            var rnd = MockRepository.GenerateMock<IRandomization>();
            rnd.Expect(r => r.GetDouble()).Return(0.1);
            RandomizationProvider.Current = rnd;

            target.Mutate(chromosome, 0);

            Assert.AreEqual(4, chromosome.Length);
            Assert.AreEqual(1, chromosome.GetGene(0).Value);
            Assert.AreEqual(2, chromosome.GetGene(1).Value);
            Assert.AreEqual(3, chromosome.GetGene(2).Value);
            Assert.AreEqual(4, chromosome.GetGene(3).Value);

            rnd.VerifyAllExpectations();
            chromosome.VerifyAllExpectations();   
        }

        [Test()]
        public void Mutate_ValidChromosome_ExchangeGenes()
        {
            var target = new TworsMutation();
            var chromosome = MockRepository.GenerateStub<ChromosomeBase>(4);
			chromosome.ReplaceGenes(0, new Gene[] 
			                                         { 
				new Gene() { Value = 1 },
				new Gene() { Value = 2 },
				new Gene() { Value = 3 }, 
                new Gene() { Value = 4 },
			});

            var rnd = MockRepository.GenerateMock<IRandomization>();
			rnd.Expect(r => r.GetUniqueInts(2, 0, 4)).Return(new int[] {0, 2});
            RandomizationProvider.Current = rnd;

            target.Mutate(chromosome, 1);

            Assert.AreEqual(4, chromosome.Length);
            Assert.AreEqual(3, chromosome.GetGene(0).Value);
            Assert.AreEqual(2, chromosome.GetGene(1).Value);
            Assert.AreEqual(1, chromosome.GetGene(2).Value);
            Assert.AreEqual(4, chromosome.GetGene(3).Value);

            rnd.VerifyAllExpectations();
            chromosome.VerifyAllExpectations();            
        }       
    }
}