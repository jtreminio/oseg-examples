package oseg.chatwoot_examples

import com.chatwoot.client.infrastructure.*
import com.chatwoot.client.apis.*
import com.chatwoot.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class DeleteAnAccountAgentBotExample
{
    fun deleteAnAccountAgentBot()
    {
        ApiClient.apiKey["api_access_token"] = "USER_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "AGENT_BOT_API_KEY"
        // ApiClient.apiKey["api_access_token"] = "PLATFORM_APP_API_KEY"

        try
        {
            AccountAgentBotsApi().deleteAnAccountAgentBot(
                accountId = 0,
                id = 0,
            )
        } catch (e: ClientException) {
            println("4xx response calling AccountAgentBotsApi#deleteAnAccountAgentBot")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AccountAgentBotsApi#deleteAnAccountAgentBot")
            e.printStackTrace()
        }
    }
}
