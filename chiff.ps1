def caesar_cipher(text, shift): 
    result = "" 
    for char in text: 
        if char.isalpha():  # Vérifier si c'est une lettre 
            shift_base = ord('A') if char.isupper() else ord('a') 
            result += chr((ord(char) - shift_base + shift) % 26 + shift_base) 
        else: 
            result += char  
    return result 
 
message = "TRY HACK ME" 
shift = 3 
encrypted_message = caesar_cipher(message, shift) 
print(f"Message chiffré : {encrypted_message}") 
 
# Fonction pour essayer tous les décalages possibles 
def brute_force_decrypt(encrypted_text): 
    for shift in range(1, 26):  # Tester tous les décalages de 1 à 25 
        decrypted_text = caesar_cipher(encrypted_text, -shift) 
        print(f"Décalage {shift}: {decrypted_text}") 
 
# Déchiffrer par brute force 
print("\nTentative de brute force :") 
brute_force_decrypt(encrypted_message) 
 
# Message à décrypter 
encrypted_text = "YMNX NX FQUMF GWFAT HTSYFHYNSL YFSLT MTYJQ RNPJ" 
 
print("\nDéchiffrement de l'énoncé :") 
brute_force_decrypt(encrypted_text) 