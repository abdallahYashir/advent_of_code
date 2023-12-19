# frozen_string_literal: true

require_relative '../lib'

def calibration_sum
  file_data = read_file(File.dirname(__FILE__), 'input.txt')

  file_data.map do |line|
    numbers = line.gsub(/[^0-9]/, '')
    (numbers[0] + numbers[-1]).to_i
  end.sum

  sum
end

def calibration_sum_part_two
  file_data = read_file(File.dirname(__FILE__), 'input.txt')

  numbers_hash = {
    'oneight' => 18,
    'oneightwo' => 182,
    'oneightwone' => 181,
    'twone' => 21,
    'one' => 1,
    'two' => 2,
    'three' => 3,
    'four' => 4,
    'five' => 5,
    'six' => 6,
    'seven' => 7,
    'eigh' => 8,
    'nine' => 9
  }

  values = file_data.map do |line|
    numbers_hash.each do |key, value|
      line = line.gsub(key, value.to_s) if line.include?(key)
    end

    numbers = line.gsub(/[^0-9]/, '')
    (numbers[0] + numbers[-1]).to_i
  end

  values.reduce(0, :+)
end
