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
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class DeletePetExample
{
    fun deletePet()
    {
        ApiClient.accessToken = "YOUR_ACCESS_TOKEN"

        try
        {
            PetApi().deletePet(
                petId = 12345,
                apiKey = "df560d5ba4eb7adbc635c87c3931a8421ae24dc81646196cd66544fd4471414a",
            )
        } catch (e: ClientException) {
            println("4xx response calling PetApi#deletePet")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PetApi#deletePet")
            e.printStackTrace()
        }
    }
}
