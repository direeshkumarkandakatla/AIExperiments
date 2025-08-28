

## for loop example with index

items:list[int] = [23, 21, 21, 22, 23]  # Type hint for integer list

for i, item in enumerate(items):
    print(f"Index: {i}, Item: {item}")