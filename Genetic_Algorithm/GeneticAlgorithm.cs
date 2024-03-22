using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    class GeneticAlgorithm
    {
        public List<double> bestSolutionsForIndividualGenerations = new List<double>();
        int populationSize;
        int chromosomeLenght;
        double crossOverRate;
        double mutationRate;
        double elitismRate;
        int generationAmount;
        private static Random rnd = new Random();

        public GeneticAlgorithm(int chromosomeLenght,
            double crossOverRate, double mutationRate,
            double elitismRate, int generationAmount, int populationSize)
        {
            this.chromosomeLenght = chromosomeLenght;
            this.crossOverRate = crossOverRate;
            this.mutationRate = mutationRate;
            this.generationAmount = generationAmount;
            this.populationSize = populationSize;
            this.elitismRate = elitismRate;
        }

        public double[] OptimizeSelectedFunctionAndReturnBestSolution()
        {
            int generationCount = 0;
            double[][] population = SetPopulation();//call the function for population settlement

            while (generationCount < generationAmount)
            {
                double[][] newpopulation = new double[populationSize][];

                int eliteCounter = (int)(populationSize * elitismRate);
                Array.Copy(SelectEliteValues(population), newpopulation, eliteCounter);

                for (int i = eliteCounter; i < populationSize; i++)
                {
                    //select 2 best parents using tournament method
                    double[] parent1 = SelectParent(population);
                    double[] parent2 = SelectParent(population);

                    double[] crossOveredChromosomSet = ArithmeticallyCrossOverParents(parent1, parent2);//crossover parents and create a new chromosom set
                    double[] mutatedChromosom = MutateChromosom(crossOveredChromosomSet);//mutate the chromosom set

                    newpopulation[i] = mutatedChromosom;//add the mutated set to newly created population set

                }

                population = newpopulation;

                var clonedPopulation = population.Clone();

                double bestSolutionForEachGeneration = ChooseBestSolutionForEachGeneration(clonedPopulation);
                bestSolutionsForIndividualGenerations.Add(bestSolutionForEachGeneration);
                
                generationCount++;

            }

            double[] bestSolution = population[0];
            double bestFitness = FitnessFunction(bestSolution);
            for (int i = 1; i < populationSize; i++)
            {
                double fitness = FitnessFunction(population[i]);
                if (fitness < bestFitness)
                {
                    bestSolution = population[i];
                    bestFitness = fitness;
                }
            }

            //select best solution
            return bestSolution;
        }

        private double ChooseBestSolutionForEachGeneration(object pop)
        {
            double[][] population = (double[][])pop;
            List<double[]> bestSolutions = population.ToList<double[]>();

            bestSolutions.Sort((x, y) => FitnessFunction(x).CompareTo(FitnessFunction(y)));

            double bestValue = FitnessFunction(bestSolutions[0]);

            return bestValue;
        }

        private double[][] SetPopulation()
        {
            double[][] population = new double[populationSize][];
            for(int i = 0; i<populationSize; i++)
            {
                population[i] = new double[chromosomeLenght];
                for (int j = 0; j < chromosomeLenght; j++)
                {
                    double gen = rnd.NextDouble() * 2000 - 1000; //min -1000 max = 1000 -+infinite symbolism
                    population[i][j] = gen;
                }
            }
            return population;
        }


        private double[][] SelectEliteValues(double[][] population)
        {
            List<double[]> elites = new List<double[]>();
            List<double[]> sortedPopulation = new List<double[]>(population);
            sortedPopulation.Sort((x, y) => FitnessFunction(x).CompareTo(FitnessFunction(y)));
            int eliteCount = (int)(populationSize * elitismRate);
            for (int i = 0; i < eliteCount; i++)
            {
                elites.Add(sortedPopulation[i]);
            }
            return elites.ToArray();
        }


        private double[] SelectParent(double[][] population)
        {
            //parent choosing method depiction (tournament used)
            double[] selectedParent = TournamentMethod(population);

            return selectedParent;
        }


        private double[] TournamentMethod(double[][] population)
        {
            int tournamentCount = 4;
            double[] bestValueCandidateChromosom = population[rnd.Next(populationSize)];

            for (int i = 1; i < tournamentCount; i++)
            {
                double[] candidateChromosom = population[rnd.Next(populationSize)]; ;

                if(FitnessFunction(candidateChromosom) < FitnessFunction(bestValueCandidateChromosom))
                {
                    bestValueCandidateChromosom = candidateChromosom;
                }
            }
            return bestValueCandidateChromosom;
            
        }

        private double[] ArithmeticallyCrossOverParents(double[] parent1, double[] parent2)//arithmetic crossover
        {
            double[] crossOveredChromosomSet = new double[parent1.Length];
            for (int i = 0; i < parent1.Length; i++)
            {
                if (rnd.NextDouble() < crossOverRate)
                {
                    double alpha = rnd.NextDouble();
                    crossOveredChromosomSet[i] = alpha * parent1[i] + (1 - alpha) * parent2[i];
                }
                else
                {
                    crossOveredChromosomSet[i] = parent1[i];
                }
            }

            return crossOveredChromosomSet;
        }
        private double[] MutateChromosom(double[] crossOveredChromosomSet)
        {
            double[] mutatedChromosom = crossOveredChromosomSet;
            for(int i = 0; i < crossOveredChromosomSet.Length; i++)
            {
                if(rnd.NextDouble() < mutationRate)
                {
                    double newlyCreatedGen = ((rnd.NextDouble() * 2000) + 1000)*0.1;
                    mutatedChromosom[i] = newlyCreatedGen;
                }
            }
            return mutatedChromosom;
        }

        public double FitnessFunction(double[] chromosom)
        {
            double sum = 0;
            foreach(double gen in chromosom)
            {
                sum += gen * gen;
            }
            return sum;
        }

    }
}
