# frozen_string_literal: true

def calibration_sum
  file_data = read_file('puzzle_one_input.txt')

  file_data.map do |line|
    numbers = line.gsub(/[^0-9]/, '')

    if numbers.length == 1
      (numbers + numbers).to_i
    else
      (numbers[0] + numbers[-1]).to_i
    end
  end.sum

  sum
end

def read_file(filename)
  file = File.open(filename, 'r')
  file_data = file.readlines.map(&:chomp)
  file.close
  file_data
end
