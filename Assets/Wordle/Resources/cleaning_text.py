def filter_five_letter_words(input_file, output_file):
    with open(input_file, 'r', encoding='utf-8') as file:
        text = file.read()

    # Split text into words
    words = text.split()

    # Filter words with exactly 5 characters
    five_letter_words = [word for word in words if len(word) == 5]

    # Write the filtered words into the output file, each on a new line
    with open(output_file, 'w', encoding='utf-8') as file:
        for word in five_letter_words:
            file.write(word + '\n')

# Example usage
filter_five_letter_words('Assets/Resources/input.txt', 'Assets\Resources\official_wordle_all.txt')