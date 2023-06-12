import os
import openai
openai.api_key = "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"
openai.Model.list()
resp = openai.Image.create(
  prompt="promt dragon scally skin pretty face fit, female, anthro, japan art background, detailed, artstation,full body negative promt (mawshot), letter box, intersex female, intersex male, fine art parody, full-package, simple background, text, grey background",
  n=2,
  size="512x512")
print(resp)