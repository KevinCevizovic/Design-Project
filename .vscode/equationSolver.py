import math
from script import *

mass = 0.0027 # kg
gravity = 9.82 # m/s^2
dragCoefficient = 1.4 # For now
density = 1.29 # kg/m^3
area = 0.02*0.02*math.pi

residual = lambda v: gravityForce(mass, gravity) - dragForce(dragCoefficient,area,density,v)

def equationSolver(residualForm, newGuess, oldGuess=0, tolerance=0.001):
    oldError = residualForm(oldGuess)
    error = abs(oldError)
    while error>tolerance:

    return newGuess


answer = equationSolver(residual, 10, 5, 0.000000001)
print("Solved at: ", answer)