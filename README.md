# code-sample

# Design Decisions

The underlying design of this solution is to focus on Solid code principals and testibility. Samples of unit tests have been provided.

Code seperation has been implemented to ensure that the salary calculation is contained in a "core" project seperate to the console input/output. This makes it more re-usable and could easily
be used in a web, mobile or desktop application.

# Improvements

There are a large number of assumptions and hard coded values that could easily be improved, examples being:
* Having a repository for Rates/Gst that can be configured based on time periods. Allowing Gst and deduction rates to change over time.
* The code allows easy introduction of new deductions
* Improve the instantiation of the payment calculator to be driven from a repository.
