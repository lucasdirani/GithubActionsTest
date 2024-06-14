﻿using Postech.PhaseOne.GroupEight.TechChallenge.Domain.Checkers.Interfaces;
using Postech.PhaseOne.GroupEight.TechChallenge.Domain.Entities;
using Postech.PhaseOne.GroupEight.TechChallenge.Domain.Interfaces.Repositories;

namespace Postech.PhaseOne.GroupEight.TechChallenge.Domain.Checkers
{
    /// <summary>
    /// Encapsulates the logic to check the record of an existing contact in the contact registration flow.
    /// </summary>
    /// <param name="contactRepository">Repository that accesses contacts stored in the database.</param>
    public class AddNewContactChecker(IContactRepository contactRepository) : IRegisteredContactChecker
    {
        private readonly IContactRepository _contactRepository = contactRepository;

        /// <summary>
        /// Checks whether the contact is registered in the database, according to the values of its properties.
        /// </summary>
        /// <param name="contactToBeChecked">Contact to be checked if it is registered in the database.</param>
        /// <returns>Returns true if the contact is already registered. Otherwise, it returns false.</returns>
        public async Task<bool> CheckRegisteredContactAsync(ContactEntity contactToBeChecked)
        {
            IEnumerable<ContactEntity> contacts = await _contactRepository.GetContactsByContactPhoneAsync(contactToBeChecked.ContactPhone);
            foreach (ContactEntity contact in contacts)
            {       
                if (contact.Equals(contactToBeChecked))
                {
                    return true;
                }
            }
            return false;
        }
    }
}