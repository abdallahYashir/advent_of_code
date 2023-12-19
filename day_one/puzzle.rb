# frozen_string_literal: true

def calibration_sum
  file_data = read_file('input.txt')

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

def calibration_sum_part_two
  file_data = read_file('input.txt')

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

    if numbers.length == 1
      (numbers + numbers).to_i
    else
      (numbers[0] + numbers[-1]).to_i
    end
  end

  values.reduce(0, :+)
end

def read_file(filename)
  file_path = File.join(File.dirname(__FILE__), filename)
  file = File.open(file_path, 'r')
  file_data = file.readlines.map(&:chomp)
  file.close
  file_data
end

puts "calibration_sum_part_two: #{calibration_sum_part_two}"
