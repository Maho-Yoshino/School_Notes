import numpy as np
import matplotlib.pyplot as plt
import sympy as sp

def plot_equation(equation):
    x = sp.symbols('x')
    
    # Parse the equation
    expr = sp.sympify(equation)

    # Find the critical points
    critical_points = sp.solve(sp.diff(expr, x), x)

    # Evaluate the derivative to determine monotonicity
    derivative = sp.diff(expr, x)

    # Convert the expression to a lambda function
    equation_function = sp.lambdify(x, expr, 'numpy')

    # Convert the derivative to a lambda function
    derivative_function = sp.lambdify(x, derivative, 'numpy')

    # Convert critical points to numerical values
    critical_points_numeric = [float(sp.N(point)) for point in critical_points]

    # Find zero points
    zero_points = sp.solve(expr, x)

    # Convert zero points to numerical values
    zero_points_numeric = [float(sp.N(point)) for point in zero_points]

    # Find intervals of monotonicity
    intervals = [(-float('inf'), critical_points_numeric[0])]  # Initial interval

    for i in range(len(critical_points_numeric) - 1):
        interval_start = critical_points_numeric[i]
        interval_end = critical_points_numeric[i + 1]
        intervals.append((interval_start, interval_end))

    intervals.append((critical_points_numeric[-1], float('inf')))  # Final interval

    # Set the range for x values
    x_min = min(critical_points_numeric + zero_points_numeric, default=-10)
    x_max = max(critical_points_numeric + zero_points_numeric, default=10)
    x_values = np.linspace(x_min - 1, x_max + 1, 1000)

    # Generate y values using the equation function
    y_values = equation_function(x_values)

    # Plot the graph
    plt.plot(x_values, y_values, label=equation)
    plt.title(f'Graph of {equation}')
    plt.xlabel('x')
    plt.ylabel('y')
    
    # Set thicker lines for x and y axes
    plt.axhline(0, color='black', linewidth=2)
    plt.axvline(0, color='black', linewidth=2)

    # Display properties
    min_value = round(min(y_values), 2)  # Round to two decimal places
    plt.text(0.1, 0.8, f'Minimum Value: {min_value}', transform=plt.gca().transAxes, fontsize=10, verticalalignment='top')
    plt.text(0.1, 0.75, f'Minimum Points: {critical_points_numeric}', transform=plt.gca().transAxes, fontsize=10, verticalalignment='top')
    plt.text(0.1, 0.7, f'Zero Points: {zero_points_numeric}', transform=plt.gca().transAxes, fontsize=10, verticalalignment='top')

    # Display intervals of monotonicity
    plt.text(0.1, 0.65, f'Monotonicity Intervals:', transform=plt.gca().transAxes, fontsize=10, verticalalignment='top')
    for interval in intervals:
        plt.text(0.1, 0.6 - 0.05 * intervals.index(interval), f'    {interval[0]} and {interval[1]}', transform=plt.gca().transAxes, fontsize=10, verticalalignment='top')

    # Display x values used
    plt.text(0.1, 0.55 - 0.05 * len(intervals), f'X Values Used: {x_min} and {x_max}', transform=plt.gca().transAxes, fontsize=10, verticalalignment='top')

    # Display monotonicity explanations
    for interval in intervals:
        x_interval = np.linspace(interval[0], interval[1], 100)
        derivative_values = derivative_function(x_interval)
        if all(np.isfinite(val) for val in derivative_values):
            if all(val > 0 for val in derivative_values):
                plt.text(0.1, 0.5 - 0.05 * intervals.index(interval), f'Monotonicity: Increasing for x in ({interval[0]}, {interval[1]})', transform=plt.gca().transAxes, fontsize=10, verticalalignment='top')
            elif all(val < 0 for val in derivative_values):
                plt.text(0.1, 0.5 - 0.05 * intervals.index(interval), f'Monotonicity: Decreasing for x in ({interval[0]}, {interval[1]})', transform=plt.gca().transAxes, fontsize=10, verticalalignment='top')
            else:
                plt.text(0.1, 0.5 - 0.05 * intervals.index(interval), f'Monotonicity: Varies for x in ({interval[0]}, {interval[1]})', transform=plt.gca().transAxes, fontsize=10, verticalalignment='top')

    plt.grid(True)
    plt.legend()
    plt.show()

# Example usage
equation_input = input("Enter an equation (e.g., 'x^2 + 2*x + 1'): ")
plot_equation(equation_input)
