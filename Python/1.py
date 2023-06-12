import os
import openai
openai.organization = "org-PNGae2EZe2UsUo3H6dSotZC0"
openai.api_key = os.getenv("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")
openai.Model.list()
response = openai.Image.create(prompt="a white siamese cat",n=1,size="1024x1024")
image_url = response['data'][0]['url']
print (image_url)