package oseg.petstore_examples

import org.openapitools.client.infrastructure.*
import org.openapitools.client.apis.*
import org.openapitools.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map

class UpdatePetWithFormExample
{
    fun updatePetWithForm()
    {
        ApiClient.accessToken = "YOUR_ACCESS_TOKEN"

        try
        {
            PetApi().updatePetWithForm(
                petId = 12345,
                name = "Pet's new name",
                status = "sold",
            )
        } catch (e: ClientException) {
            println("4xx response calling PetApi#updatePetWithForm")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PetApi#updatePetWithForm")
            e.printStackTrace()
        }
    }
}
